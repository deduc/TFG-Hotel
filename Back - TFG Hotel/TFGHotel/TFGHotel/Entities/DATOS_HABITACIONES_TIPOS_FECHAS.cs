using System.Text.Json.Serialization;

namespace TFGHotel.Entities
{
    public class DATOS_HABITACIONES_TIPOS_FECHAS
    {
        [JsonPropertyName("ID_HABITACION")]
        public int ID_HABITACION { get; set; }

        [JsonPropertyName("ID_CLIENTE")]
        public int ID_CLIENTE{ get; set; }

        [JsonPropertyName("ID_TIPO_DE_HABITACION")]
        public int ID_TIPO_DE_HABITACION { get; set; }
        
        [JsonPropertyName("CATEGORIA")]
        public string CATEGORIA { get; set; }
        
        [JsonPropertyName("FECHA_INICIO")]
        public DateTime FECHA_INICIO { get; set; }
        
        [JsonPropertyName("FECHA_FIN")]
        public DateTime FECHA_FIN { get; set; }
    }
}
