using Microsoft.AspNetCore.Mvc;
using rpg_training.DBContext;
using rpg_training.DTOs.UserDTO;

namespace rpg_training.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentification _authentification;

        public AuthentificationController(IAuthentification authentification) {
            _authentification=authentification;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> register(RegisterUserDTO user)
        {
            return Ok(await _authentification.Register(user));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginUserDTO user)
        {
            return Ok(await _authentification.Login(user));
        }
    }
}
