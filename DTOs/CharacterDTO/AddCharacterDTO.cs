namespace rpg_training.DTOs.CharacterDTO
{
    public class AddCharacterDTO
    {
        //other properties are by default
        public string Name { get; set; } = "";
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}
