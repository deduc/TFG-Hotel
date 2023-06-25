using System.Text.Json.Serialization;

namespace TFGHotel.Entities
{
    public class RESERVAS_DE_SERVICIOS
    {
        [JsonPropertyName("ID_RESERVA_SERVICIO")]
        public int ID_RESERVA_SERVICIO { get; set; }

        [JsonPropertyName("ID_CLIENTE")]
        public int ID_CLIENTE { get; set; }

        [JsonPropertyName("ID_SERVICIO")]
        public int ID_SERVICIO { get; set; }

        [JsonPropertyName("RESERVA_ACTIVA")]
        public int RESERVA_ACTIVA { get; set; }
    }
}
