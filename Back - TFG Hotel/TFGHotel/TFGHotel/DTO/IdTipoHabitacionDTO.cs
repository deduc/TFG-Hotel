using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class IdTipoHabitacionDTO
    {
        [JsonPropertyName("IdHabitacion")]
        public int IdHabitacion { get; set; }
    }
}
