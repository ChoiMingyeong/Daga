using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpsCommon;
using OpsDBApi.DB;

namespace OpsDBApi.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly OpsDbContext _context;

        public AccountController(OpsDbContext opsDbContext)
        {
            _context = opsDbContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Account?>> LoginAsync([FromBody] Login login)
        {
            var dbAccount = await _context.Accounts.SingleOrDefaultAsync(p=>p.Email == login.Email && p.Password == login.Password);
            if (null == dbAccount)
            {
                return NotFound(null);
            }

            return Ok(new Account { Id = dbAccount.Id, Email = dbAccount.Email, Name = dbAccount.Name });
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Account account)
        {
            var dbAccount = await _context.Accounts.SingleOrDefaultAsync(p => p.Id == account.Id);
            if (null == dbAccount)
            {
                return NotFound(null);
            }

            dbAccount.Name = account.Name;
            await _context.SaveChangesAsync();

            return Ok(new Account { Id = dbAccount.Id, Email = dbAccount.Email, Name = dbAccount.Name });
        }
    }
}
