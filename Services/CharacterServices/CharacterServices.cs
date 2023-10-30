using AutoMapper;
using rpg_training.DBContext;
using rpg_training.DTOs.CharacterDTO;
using System.Security.Claims;

namespace rpg_training.Services.CharacterServices
{
    public class CharacterServices : ICharacterServices
    {
        
        private readonly IMapper _mapper;
        private readonly appDBcontext _dbcontext;
        private readonly IHttpContextAccessor _httpcontextaccessor;

        public CharacterServices(IMapper mapper, appDBcontext appDBcontext,IHttpContextAccessor httpContextAccessor)
        {
            _mapper=mapper;
            _dbcontext=appDBcontext;
            _httpcontextaccessor=httpContextAccessor;
        }
        private int getUserId()=>int.Parse(_httpcontextaccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<Object>> AddCharacter(AddCharacterDTO character)
        {
            try
            {
                var res = _mapper.Map<Character>(character);
                res.User=await _dbcontext.users.FirstOrDefaultAsync(u=>u.Id==getUserId());
                await _dbcontext.AddAsync(res);
                await _dbcontext.SaveChangesAsync();
                return new ServiceResponse<object> { Message = "Character added" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object> { Message = ex.Message,Success=false };
            }
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            try
            {
                var characters = await _dbcontext.characters.Where(c=>c.User!.Id==getUserId()).ToListAsync();
                return new ServiceResponse<List<GetCharacterDTO>>

                {
                    obj = characters.Select(item => _mapper.Map<GetCharacterDTO>(item)).ToList()
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<GetCharacterDTO>> { Message = ex.Message, Success = false };
            }
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id)
        {
            try
            {
                var res = await _dbcontext.characters.FirstOrDefaultAsync(c => c.id == id);
                if (res == null) { return new ServiceResponse<GetCharacterDTO> { Message = "character Not found", Success = false }; }
                return new ServiceResponse<GetCharacterDTO> { obj = _mapper.Map<GetCharacterDTO>(res) };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetCharacterDTO> { Message = ex.Message, Success = false };
            }

        }

        public async Task<ServiceResponse<object>> UpdateCharacter(UpdateCharacterDTO update_character)
        {
            try
            {
                var character = await _dbcontext.characters.FirstOrDefaultAsync(item => item.id == update_character.id);
                if (character == null)
                {
                    return new ServiceResponse<object> { Message = "character not found", Success = false };
                }
                character.Name = update_character.Name;
                character.Strength = update_character.Strength;
                character.Defense = update_character.Defense;
                character.Intelligence = update_character.Intelligence;
                character.Hitpoints = update_character.Hitpoints;
                _dbcontext.Entry(character).State= EntityState.Modified;
                await _dbcontext.SaveChangesAsync();
                return new ServiceResponse<object> { Message = "character updated" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<object> { Message = ex.Message, Success = false };
            }
        }


        public async Task<ServiceResponse<GetCharacterDTO>> RemoveCharacter(int id)
        {
            try
            {

                var character = await _dbcontext.characters.FirstOrDefaultAsync(item => item.id == id);
                if (character == null)
                {
                    return new ServiceResponse<GetCharacterDTO> { Message = "character not found", Success = false };
                }

                _dbcontext.Remove(character);
                await _dbcontext.SaveChangesAsync();

                return new ServiceResponse<GetCharacterDTO>
                {
                    Message = "item deleted",
                    obj = _mapper.Map<GetCharacterDTO>(character)
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetCharacterDTO> { Message = ex.Message, Success = false };
            }



        }
    }
}
