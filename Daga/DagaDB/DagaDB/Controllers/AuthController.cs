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