using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DagaServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        public ChatController()
        {

        }

        [HttpPost(Name = "chat")]
        public string Post(string msg)
        {
            StringBuilder stringBuilder = new StringBuilder();

            return stringBuilder.ToString();
        }
    }
}
