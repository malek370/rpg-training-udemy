using rpg_training.DTOs.SkillDTO;

namespace rpg_training.DTOs.CharacterDTO
{
    public class GetCharacterDTO
    {
        public int id { get; set; }
        public string Name { get; set; } = "malek";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
        public GetWeaponDTO? Weapon { get; set; }
        public List<GetSkillDTO>? Skills { get; set; }
    }
}
