using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rpg_training.DTOs.CharacterDTO;
using rpg_training.Services.WeaponServices;

namespace rpg_training.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponServices _weaponServices;
        public WeaponController(IWeaponServices weaponServices)
        {
            _weaponServices = weaponServices;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddWeaponDTO weapon)
        {
            return Ok(await _weaponServices.Add(weapon));
        }
    }
}
