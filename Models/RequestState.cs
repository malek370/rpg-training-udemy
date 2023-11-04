using System.Text.Json.Serialization;

namespace rpg_training.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RequestState
    {
        accepted = 1,
        refused = 2,
        waiting = 3
    }
}
