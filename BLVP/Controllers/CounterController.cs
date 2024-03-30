using BLVP.Models.Request;
using BLVP.Repository.CounterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLVP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;
        public CounterController(ICounterService counterService) 
        {
            _counterService = counterService;
        }
        [HttpGet("inc")]
        public async Task<IActionResult> IncreaseCounter()
        {
            await _counterService.IncreaseCounterAsync(new CreateCounterModel());
            return Ok();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetCurrentCounter([FromQuery] string key)
        {
            var counter = await _counterService.GetCounterByKey(key);
            return Ok(counter);
        }
    }
}
