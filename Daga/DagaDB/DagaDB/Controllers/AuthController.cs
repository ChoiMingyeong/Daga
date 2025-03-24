using DagaCommon.Models;
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
    public async Task<IActionResult> LoginAsync([FromBody] Login data)
    {
        return Ok(new Account
        {
            ID = 1,
            RoleID = 1,
            Email = data.Email,
            Projects = [ new Project {
                    ID = 1,
                    Name = "Project 1",
                    Roles = [],
                    Accounts = [],
                    DataTables = []
                }],
        });
    }
}