using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class ClientesDTO
    {
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("Apellidos")]
        public string Apellidos { get; set; }
    }
}
