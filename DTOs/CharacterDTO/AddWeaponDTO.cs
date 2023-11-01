namespace rpg_training.DTOs.CharacterDTO
{
    public class AddWeaponDTO
    {
        public string Name { get; set; } = "";
        public int Damage { get; set; }
        public int CharacterId { get; set; }
    }
}
