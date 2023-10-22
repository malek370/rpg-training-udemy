namespace rpg_training.DTOs.CharacterDTO
{
    public class UpdateCharacterDTO
    {
        //you can not update the class of the character
        public int id { get; set; }
        public string Name { get; set; } = "malek";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
    }
}
