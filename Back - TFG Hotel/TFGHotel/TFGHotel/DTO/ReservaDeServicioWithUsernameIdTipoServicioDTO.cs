using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class ReservaDeServicioWithUsernameIdTipoServicioDTO
    {
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("Id_Servicio")]
        public int Id_Servicio { get; set; }
    }
}
