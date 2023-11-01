namespace rpg_training.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Damage { get; set; } = 10;
        public Character? Character { get; set; }
        public int? CharacterId { get; set; }
    }
}
