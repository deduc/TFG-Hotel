using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class FechaInicioFinDTO
    {
        [JsonPropertyName("FechaInicio")]

        public DateTime FechaInicio { get; set; }
        [JsonPropertyName("FechaFin")]
        public DateTime FechaFin { get; set; }
    }
}
