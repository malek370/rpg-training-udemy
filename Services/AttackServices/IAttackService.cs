using rpg_training.DTOs.AttackDTO;

namespace rpg_training.Services.AttackServices
{
    public interface IAttackService
    {
        public Task<ServiceResponse<AttackResultDTO>> WeaponAttack(WeaponAttackDTO weaponAttack);
        public Task<ServiceResponse<AttackResultDTO>> SkillAttack(SkillAttackDTO skillAttack);
    }
}
