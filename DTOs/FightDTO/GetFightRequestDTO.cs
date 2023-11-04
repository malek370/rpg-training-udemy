namespace rpg_training.DTOs.FightDTO
{
    public class GetFightRequestDTO
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string characterName { get; set;}
        public string RecieverName { get; set;}
    }
}
