namespace rpg_training.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public byte[]? HashedPassword { get; set; }
        public byte[]? SaltPassword { get; set; }
        public List<Character>? Characters { get; set; }
    }
}
