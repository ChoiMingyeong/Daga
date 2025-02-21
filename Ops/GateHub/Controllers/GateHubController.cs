using Microsoft.AspNetCore.Mvc;
using OpsCommon;

namespace GateHub.Controllers
{
    [ApiController]
    public class GateHubController : ControllerBase
    {
        private readonly RedisService _redisService;

        public GateHubController(RedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpPost("gatehub")]
        public IActionResult RequestGateHub([FromBody] string version)
        {
            if(false == _redisService.Gates.TryGetValue(version, out var state))
            {
                return BadRequest();
            }
            else
            {
                return Ok(state);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> RequsetCreate([FromBody] Gate gate)
        {
            if (await _redisService.PublishCreateAsync(gate))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("update")]
        public async Task<IActionResult> RequsetUpdate([FromBody] Gate gate)
        {
            if (await _redisService.PublishUpdateAsync(gate))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("delete")]
        public async Task<IActionResult> RequsetDelete([FromBody] string version)
        {
            if (true == await _redisService.PublishDeleteAsync(version))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("list")]
        public IActionResult RequsetList()
        {
            return Ok(_redisService.GetGateList());
        }
    }
}
