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
        return Ok();
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