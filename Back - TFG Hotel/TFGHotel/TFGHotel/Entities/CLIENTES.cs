using System.Text.Json.Serialization;

namespace TFGHotel.Entities
{
    public class CLIENTES
    {
        [JsonPropertyName("ID_CLIENTE")]
        public int ID_CLIENTE { get; set; }
        
        [JsonPropertyName("NOMBRE")]
        public string NOMBRE { get; set; }
        
        [JsonPropertyName("APELLIDOS")]
        public string APELLIDOS { get; set; }
        
        [JsonPropertyName("USERNAME")]
        public string USERNAME { get; set; }
        
        [JsonPropertyName("DNI")]
        public string DNI { get; set; }
        
        [JsonPropertyName("EMAIL")]
        public string EMAIL { get; set; }
    }
}
