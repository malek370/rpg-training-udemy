using System.Text.Json.Serialization;

namespace rpg_training.Models
{
    
    public class FightRequest
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int charachterId { get; set; }
        public int ReceiverId { get; set; }
        public RequestState State { get; set; }=RequestState.waiting;
        public DateTime CreationDate { get; set; }=DateTime.Now;
    }
}
