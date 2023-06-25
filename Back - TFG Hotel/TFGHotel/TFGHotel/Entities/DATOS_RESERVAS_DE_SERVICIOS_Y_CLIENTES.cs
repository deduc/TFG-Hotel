using System.Text.Json.Serialization;

namespace TFGHotel.Entities
{
    public class DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES
    {
        [JsonPropertyName("ID_RESERVA_SERVICIO")]
        public int ID_RESERVA_SERVICIO { get; set; }
        
        [JsonPropertyName("ID_CLIENTE")]
        public int ID_CLIENTE { get; set; }
        
        [JsonPropertyName("NOMBRE_SERVICIO")]
        public string NOMBRE_SERVICIO { get; set; }
        
        [JsonPropertyName("PRECIO")]
        public decimal PRECIO { get; set; }
    }
}
