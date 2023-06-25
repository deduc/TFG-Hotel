using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class ReservasDeHabitacionesDTO
    {
        [JsonPropertyName("Id_Cliente")]
        public int Id_Cliente { get; set; }

        [JsonPropertyName("Id_Habitacion")]
        public int Id_Habitacion { get; set; }

        [JsonPropertyName("Fecha_Inicio")]
        public DateTime Fecha_Inicio { get; set; }

        [JsonPropertyName("Fecha_Fin")]
        public DateTime Fecha_Fin { get; set; }
    }
}
