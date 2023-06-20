using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class UsuariosDTO
    {
        [JsonPropertyName("ID_USUARIO")]
        public int ID_USUARIO { get; set; }

        [JsonPropertyName("USERNAME")]
        public string USERNAME { get; set; }

        [JsonPropertyName("EMAIL")]
        public string EMAIL { get; set; }

        [JsonPropertyName("DNI")]
        public string DNI { get; set; }

        [JsonPropertyName("PASSWORD")]
        public string PASSWORD { get; set; }

        [JsonPropertyName("NOMBRE")]
        public string NOMBRE { get; set; }

        [JsonPropertyName("APELLIDOS")]
        public string APELLIDOS { get; set; }

        [JsonPropertyName("FOTO_DE_PERFIL_BASE_64")]
        public string FOTO_DE_PERFIL_BASE_64 { get; set; }
    }
}
