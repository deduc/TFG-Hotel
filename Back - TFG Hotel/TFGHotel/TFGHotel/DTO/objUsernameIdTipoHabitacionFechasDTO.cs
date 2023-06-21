using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class objUsernameIdTipoHabitacionFechasDTO
    {
        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("idTipoHabitacion")]
        public int idTipoHabitacion { get; set; }

        [JsonPropertyName("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("FechaFin")]
        public DateTime FechaFin { get; set; }
    }
}
