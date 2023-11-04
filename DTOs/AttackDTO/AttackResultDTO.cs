namespace rpg_training.DTOs.AttackDTO
{
    public class AttackResultDTO
    {
        public string attacker { get; set; } = "";
        public string defender { get; set; } = "";
        public int damage { get; set; }
        public int defenderHpoint { get; set; }
    }
}
