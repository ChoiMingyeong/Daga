using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DagaServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {

        }

        [HttpPost(Name = "login")]
        public string Post()
        {
            StringBuilder stringBuilder = new StringBuilder();
            return stringBuilder.ToString();
        }
    }
}
