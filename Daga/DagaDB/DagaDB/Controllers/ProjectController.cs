using DagaCommon.Models;
using DagaCommon.Protocol;
using DagaDB.DB;
using DagaDB.DB.Tables;
using Microsoft.AspNetCore.Mvc;

namespace DagaDB.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    public ProjectController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RequestCreateProject recPacket)
    {
        ProjectTable dbProject = new()
        {
            ID = ProjectTable.CreateID++,
            Name = recPacket.ProjectName,
        };

        RoleTable dbGuestRole = new()
        {
            ProjectID = dbProject.ID,
            ID = Role.Guest.ID,
            Name = Role.Guest.Name,
            Description = Role.Guest.Description,
        };
        RoleTable dbAdminRole = new()
        {
            ProjectID = dbProject.ID,
            ID = Role.Admin.ID,
            Name = Role.Admin.Name,
            Description = Role.Admin.Description,
        };

        ProjectAccountTable dbProjectAccount = new()
        {
            ProjectID = dbProject.ID,
            AccountID = recPacket.AccountID,
            RoleID = Role.Admin.ID,
        };

        DagaDbContext.Instance.Projects.Add(dbProject);
        DagaDbContext.Instance.Roles.AddRange(dbGuestRole, dbAdminRole);
        DagaDbContext.Instance.ProjectAccounts.Add(dbProjectAccount);

        return Ok(new ResponseCreateProject { ProjectID = dbProject.ID });
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromBody] uint accountID)
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] RequestDeleteProject recPacket)
    {
        return Ok();
    }
}