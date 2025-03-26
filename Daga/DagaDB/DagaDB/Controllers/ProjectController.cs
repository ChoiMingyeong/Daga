using DagaCommon.Models;
using DagaCommon.Protocol;
using DagaDB.DB;
using DagaDB.DB.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

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
            Description = recPacket.ProjectDescription,
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

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] uint accountID)
    {
        List<Project> projects = [];
        var dbProjectIDs = DagaDbContext.Instance.ProjectAccounts.Where(p => p.AccountID == accountID).Select(p => p.ProjectID).ToList();
        var dbProjects = DagaDbContext.Instance.Projects.Where(p => dbProjectIDs.Contains(p.ID)).ToList();

        foreach (var dbProject in dbProjects)
        {
            var dbAccounts = DagaDbContext.Instance.ProjectAccounts
                .Where(p => p.ProjectID == dbProject.ID)
                .ToList();
            var permissions = DagaDbContext.Instance.Permissions
                .Where(p => p.ProjectID == dbProject.ID)
                .ToDictionary(p => p.PermissionType, p => p.Privileges);
            var roles = DagaDbContext.Instance.Roles
                .Where(p => p.ProjectID == dbProject.ID)
                .Select(p => new Role() { ID = p.ID, Name = p.Name, Description = p.Description, Permissions = permissions, })
                .ToList();

            Project project = new()
            {
                ID = dbProject.ID,
                Name = dbProject.Name,
                Favorite = dbAccounts.Single(p => p.AccountID == accountID).Favorite,
                Description = dbProject.Description,
                Roles = roles,
                Accounts = dbAccounts.ToDictionary(p => p.AccountID, p => p.RoleID),
            };

            projects.Add(project);
        }

        return Ok(projects);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchAsync([FromBody] RequestUpdateProjectFavorite recPacket)
    {
        var dbProjectAccount = DagaDbContext.Instance.ProjectAccounts.SingleOrDefault(p => p.ProjectID == recPacket.ProjectID && p.AccountID == recPacket.AccountID);
        if (null == dbProjectAccount)
        {
            return NotFound();
        }

        dbProjectAccount.Favorite = recPacket.Favorite;
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] RequestDeleteProject recPacket)
    {
        return Ok();
    }
}