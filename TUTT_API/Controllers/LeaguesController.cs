using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TUTT_API.Models;
using TUTT_API.Services;

namespace TUTT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaguesController : Controller
    {
        private readonly ILeaguesService _service;

        public LeaguesController(ILeaguesService service)
        {
            _service = service;


        }
        [HttpGet("GetLeagues")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLeagues(string? key, int offset, int limit, string? sortField, bool isAsc=false)
        {
            var total = 0;
            var data = _service.GetAll(key, offset, limit, sortField, out total);
            //return data;
            return Ok(Result.Success(data, total, $"ok"));
        }
    }
}
