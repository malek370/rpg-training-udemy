using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rpg_training.DTOs.FightDTO;
using rpg_training.Services.FightServices;

namespace rpg_training.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly IFightServices _fightServices;
        public FightController(IFightServices fightServices) 
        {
            _fightServices = fightServices;
        }
        [HttpGet("MyRequests")]
        public async Task<ActionResult> GetRequests()
        {
            return Ok(await _fightServices.GetRequests());
        }
        [HttpPost("MakeRequest")]
        public async Task<ActionResult> MakeRequest(MakeFightRequestDTO request)
        {
            return Ok(await _fightServices.MakeRequest(request));
        }
    }
}
