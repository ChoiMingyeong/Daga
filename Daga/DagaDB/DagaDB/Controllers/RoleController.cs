using DagaCommon.Models;
using DagaCommon.Protocol;
using Microsoft.AspNetCore.Mvc;

namespace DagaDB.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private Dictionary<ulong, List<Role>> _roles = [];

    public RoleController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RequestCreateRole recPacket)
    {


        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] ulong projectID)
    {


        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Async([FromBody] Role data)
    {


        return Ok();
    }
}
