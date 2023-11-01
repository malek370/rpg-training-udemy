using AutoMapper;
using rpg_training.DBContext;
using rpg_training.DTOs.CharacterDTO;
using rpg_training.Models;
using System.Security.Claims;

namespace rpg_training.Services.WeaponServices
{
    public class WeaponServices : IWeaponServices
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        private readonly appDBcontext _dBcontext;
        public WeaponServices(IHttpContextAccessor httpContext,IMapper mapper,appDBcontext dBcontext)
        {
            _contextAccessor = httpContext;
            _mapper = mapper;
            _dBcontext = dBcontext;
        }
        private int getUserId => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetCharacterDTO>> Add(AddWeaponDTO newWeapon)
        {
            try
            {
                var character=await _dBcontext.characters
                    .Include(c=>c.Weapon)
                    .FirstOrDefaultAsync(c=>c.id==newWeapon.CharacterId && c.User.Id==getUserId);
                if(character==null) { throw new Exception("user not found"); }
                if (character.Weapon != null) { throw new Exception("character already has a weapon"); }
                var weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character=character
                };
                await _dBcontext.weapons.AddAsync(weapon);
                await _dBcontext.SaveChangesAsync();
                return new ServiceResponse<GetCharacterDTO> { obj = _mapper.Map<GetCharacterDTO>(character) };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetCharacterDTO> { obj = null,Message=ex.Message,Success=false};
            }
        }
    }
}
