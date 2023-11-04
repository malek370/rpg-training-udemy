using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rpg_training.DTOs.AttackDTO;
using rpg_training.Services.AttackServices;
using System.Runtime.CompilerServices;

namespace rpg_training.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttackController : ControllerBase
    {
        private readonly IAttackService _attackService;
        public AttackController(IAttackService attackService) 
        {
            _attackService = attackService;
        }

        [HttpPost("weapon")]
        public async Task<IActionResult> WeaponAttack(WeaponAttackDTO wa)
        {
            if (wa == null) { return NotFound(); }
            return Ok(await _attackService.WeaponAttack(wa));
        }
        [HttpPost("skill")]
        public async Task<IActionResult> SkillAttack(SkillAttackDTO sa)
        {
            if (sa == null) { return NotFound(); }
            return Ok(await _attackService.SkillAttack(sa) );
        }

    }
}
