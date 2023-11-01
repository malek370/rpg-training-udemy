using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpg_training.DTOs.CharacterDTO;
using rpg_training.DTOs.SkillDTO;
using rpg_training.Models;
using rpg_training.Services.CharacterServices;
using System.ComponentModel;
using System.Security.Claims;

namespace rpg_training.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterServices _characterSurvices;

        public CharacterController(ICharacterServices characterServices)
        {
            _characterSurvices= characterServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _characterSurvices.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
        {
            return Ok(await _characterSurvices.GetCharacter(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<object>>> PostCharacter(AddCharacterDTO character) 
        {
            return Ok(await _characterSurvices.AddCharacter(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<object>>> UpdateCharacter(UpdateCharacterDTO character)
        {
            return Ok(await _characterSurvices.UpdateCharacter(character));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            return Ok(await _characterSurvices.RemoveCharacter(id));
        }

        [HttpPut("skillCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> AddSkillCharacter(addSkillCharacterDTO addskill)
        {
            return Ok(await _characterSurvices.AddSkillToCharacter(addskill));
        }
    }

}
