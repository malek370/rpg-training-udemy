using rpg_training.DTOs.CharacterDTO;

namespace rpg_training.Services.WeaponServices
{
    public interface IWeaponServices
    {
        public Task<ServiceResponse<GetCharacterDTO>> Add(AddWeaponDTO newWeapon);
    }
}
