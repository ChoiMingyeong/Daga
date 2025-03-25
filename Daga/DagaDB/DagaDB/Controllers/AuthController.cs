using DagaCommon.Models;
using DagaCommon.Protocol;
using DagaDB.DB;
using DagaDB.DB.Tables;
using Microsoft.AspNetCore.Mvc;

namespace DagaDB.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    public AuthController()
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] RequestLogin recPacket)
    {
        var dbAccount = DagaDbContext.Instance.Accounts.SingleOrDefault(p => p.Email == recPacket.Email && p.Password == recPacket.Password);
        if (null == dbAccount)
        {
            return NotFound();
        }

        ResponseLogin resPacket = new()
        {
            AccountID = dbAccount.ID,
            Name = dbAccount.Name,
        };

        var projectIDs = DagaDbContext.Instance.ProjectAccounts.Where(p => p.AccountID == dbAccount.ID).Select(p => p.ProjectID).ToList();
        foreach (var projectID in projectIDs)
        {
            var dbProject = DagaDbContext.Instance.Projects.SingleOrDefault(p => p.ID == projectID);
            if (null == dbProject)
            {
                continue;
            }

            var permissions = DagaDbContext.Instance.Permissions
                .Where(p => p.ProjectID == projectID)
                .ToDictionary(p => p.PermissionType, p => p.Privileges);

            var roles = DagaDbContext.Instance.Roles
                .Where(p => p.ProjectID == projectID)
                .Select(p => new Role() { ID = p.ID, Name = p.Name, Description = p.Description, Permissions = permissions, })
                .ToList();

            var accounts = DagaDbContext.Instance.ProjectAccounts
                .Where(p => p.ProjectID == projectID)
                .ToDictionary(p=> p.AccountID, p=>p.RoleID);

            Project project = new()
            {
                ID = dbProject.ID,
                Name = dbProject.Name,
                Roles = roles,
                Accounts = accounts,
                DataTables = [],
            };

            resPacket.Projects.Add(project);
        }

        return Ok(resPacket);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignupAsync([FromBody] RequestSignup recPacket)
    {
        var dbAccount = DagaDbContext.Instance.Accounts.SingleOrDefault(p => p.Email == recPacket.Email);
        if(null != dbAccount)
        {
            return BadRequest();
        }

        dbAccount = new()
        {
            ID = AccountTable.CreateID++,
            Name = recPacket.Nickname,
            Email = recPacket.Email,
            Password = recPacket.Password,
        };
        DagaDbContext.Instance.Accounts.Add(dbAccount);

        return Ok();
    }
}