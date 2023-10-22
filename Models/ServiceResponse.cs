namespace rpg_training.Models
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }=true; 
        public string Message { get; set; } = "";
        public T? obj { get; set; }
    }
}
