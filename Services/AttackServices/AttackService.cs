using rpg_training.DBContext;
using rpg_training.DTOs.AttackDTO;
using System.Security.Claims;

namespace rpg_training.Services.AttackServices
{
    public class AttackService : IAttackService
    {
        //need to make action if defeated 
        private readonly appDBcontext _appDBcontext;
        private readonly IHttpContextAccessor _contextAccessor;
        public AttackService(IHttpContextAccessor httpContextAccessor,appDBcontext appDBcontext) {
            
            _appDBcontext = appDBcontext;
            _contextAccessor = httpContextAccessor;
        }
        private int getUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<AttackResultDTO>> SkillAttack(SkillAttackDTO skillAttack)
        {
            try
            {
                //get attacker
                var attacker = await _appDBcontext.characters
                                 .Include(c => c.Skills)
                                 .Include(c => c.User)
                                 .FirstOrDefaultAsync(c => c.id == skillAttack.AttackerID && c.User.Id == getUserId());
                //get defender
                var defender = await _appDBcontext.characters
                                 .FirstOrDefaultAsync(c => c.id == skillAttack.DefenderID);
                //check if characters exist and attacker has the weapon
                if (attacker == null || defender == null || attacker.Skills==null || attacker.Skills.Where(c=>c.Id==skillAttack.SkillID)==null) { throw new Exception("something is wrong"); }
                //calculate damage
                int damage = attacker.Strength - defender.Defense + attacker.Skills.FirstOrDefault(c => c.Id == skillAttack.SkillID)!.Damage;
                damage = damage > 0 ? damage : 0;
                string message = "";
                defender.Hitpoints -= damage;
                //prepare response
                var res = new AttackResultDTO
                {
                    attacker = attacker.Name,
                    defender = defender.Name,
                    damage = damage,
                    defenderHpoint = defender.Hitpoints
                };
                //check if defender defeated
                if (defender.Hitpoints <= 0)
                {
                    message = $"{defender.Name} got defeated";
                    attacker.wins++;
                    defender.loss++;
                }
                await _appDBcontext.SaveChangesAsync();

                return new ServiceResponse<AttackResultDTO> { obj = res, Message = message };
                
                
            }
            catch (Exception ex) { return new ServiceResponse<AttackResultDTO> { Success = false, Message = ex.Message, obj = null }; }
        }

        public async Task<ServiceResponse<AttackResultDTO>> WeaponAttack(WeaponAttackDTO weaponAttack)
        {
            try
            {
                var attacker = await _appDBcontext.characters
                                 .Include(c => c.Weapon)
                                 .Include(c => c.User)
                                 .FirstOrDefaultAsync(c => c.id == weaponAttack.AttackerID && c.User.Id == getUserId());
                var defender = await _appDBcontext.characters
                                 .FirstOrDefaultAsync(c => c.id == weaponAttack.DefenderID);
                int damage;
                string message = "";
                if (attacker == null || defender == null) { throw new Exception("something is wrong"); }
                if (attacker.Weapon != null) {damage = attacker.Strength + attacker.Weapon.Damage - defender.Defense; }
                else {  damage = attacker.Strength - defender.Defense; }
                damage= damage > 0 ? damage : 0;
                defender.Hitpoints -= damage;
                var res = new AttackResultDTO
                {
                    attacker = attacker.Name,
                    defender = defender.Name,
                    damage = damage,
                    defenderHpoint = defender.Hitpoints
                };
                if (defender.Hitpoints <= 0)
                {
                    message = $"{defender.Name} got defeated";
                     attacker.wins++;
                    defender.loss++;
                }
                await _appDBcontext.SaveChangesAsync();
                
                return new ServiceResponse<AttackResultDTO> { obj=res, Message=message };

                
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AttackResultDTO>{Success = false, Message=ex.Message , obj=null}; 
            }
        }

    }
}
