

using rpg_training.DTOs.CharacterDTO;
using rpg_training.DTOs.SkillDTO;
using rpg_training.Models;

namespace rpg_training.Services.CharacterServices
{
    public interface ICharacterServices
    {
        public Task<ServiceResponse<Object>> AddCharacter(AddCharacterDTO character);
        public Task<ServiceResponse<GetCharacterDTO>> RemoveCharacter(int ids);
        public Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id);
        public Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        public Task<ServiceResponse<object>> UpdateCharacter(UpdateCharacterDTO update_character);
        public Task<ServiceResponse<GetCharacterDTO>> AddSkillToCharacter(addSkillCharacterDTO addskill);
    }
}
