using DagaCommon.Models;
using DagaCommon.Protocol;
using Microsoft.AspNetCore.Mvc;

namespace DagaDB.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private Dictionary<ulong, Project> _projects = [];

    public ProjectController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RequestCreateProject recPacket)
    {
        Project project = new()
        {
            Name = recPacket.ProjectName,
            Roles = [Role.Guest, Role.Admin],
            Accounts = { { recPacket.AccountID, Role.Admin } },
            DataTables = []
        };
        _projects[project.ID] = project;

        return Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromBody] uint accountID)
    {
        return Ok(_projects.Where(p => p.Value.Accounts.ContainsKey(accountID)).Select(p => p.Value).ToList());
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] RequestDeleteProject recPacket)
    {
        if(false == _projects.TryGetValue(recPacket.ProjectID, out var project))
        {
            return NotFound();
        }

        if(false == project.Accounts.TryGetValue(recPacket.AccountID, out var role) 
            || role != Role.Admin)
        {
            return BadRequest();
        }

        if(false == _projects.Remove(recPacket.ProjectID))
        {
            return BadRequest();
        }

        return Ok();
    }
}