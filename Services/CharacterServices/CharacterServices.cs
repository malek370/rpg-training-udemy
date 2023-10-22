using AutoMapper;
using rpg_training.DTOs.CharacterDTO;

namespace rpg_training.Services.CharacterServices
{
    public class CharacterServices : ICharacterServices
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character(){id=1,Name="Slim",Class=RPGClass.Mage},
            new Character(){id=2,Name="chaima",Class=RPGClass.Knight},
            new Character(){id=3,Name="Mariem",Class=RPGClass.Cleric}
        };
        private static int Ids = 4;
        private readonly IMapper _mapper;
        public CharacterServices(IMapper mapper)
        {
            _mapper=mapper;
        }

        public async Task<ServiceResponse<Object>> AddCharacter(AddCharacterDTO character)
        {
            var res = _mapper.Map<Character>(character);
            res.id = Ids++;
            characters.Add(res);
            return new ServiceResponse<object> { Message = "Character added" };
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDTO>> 
            { 
                obj = characters.Select(item=>_mapper.Map<GetCharacterDTO>(item)).ToList() 
            };
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id)
        {
            var res=characters.FirstOrDefault(c => c.id == id);
            if (res == null) { return new ServiceResponse<GetCharacterDTO> { Message="character Not found",Success=false }; }
            return new ServiceResponse<GetCharacterDTO> { obj = _mapper.Map<GetCharacterDTO>(res) };
        }

        public async Task<ServiceResponse<object>> UpdateCharacter(UpdateCharacterDTO update_character)
        {
            var character=characters.FirstOrDefault(item=>item.id==update_character.id);
            if(character == null)
            {
                return new ServiceResponse<object> { Message = "character not found",Success=false };
            }
            character.Name=update_character.Name;
            character.Strength=update_character.Strength;
            character.Defense=update_character.Defense;
            character.Intelligence =update_character.Intelligence;
            character.Hitpoints=update_character.Hitpoints;
            return new ServiceResponse<object> { Message="character updated" };
        }


        public async Task<ServiceResponse<GetCharacterDTO>> RemoveCharacter(int id)
        {
            foreach (var item in characters)
            {
                Character? res;
                if (id == item.id)
                {
                    res = item;
                    characters.Remove(item);

                    return new ServiceResponse<GetCharacterDTO> 
                    {
                        Message = "item deleted",
                        obj = _mapper.Map<GetCharacterDTO>(res)
                    };
            
                }
            }
            return new ServiceResponse<GetCharacterDTO> { Message = "item not found", Success = false };
        }
    }
}
