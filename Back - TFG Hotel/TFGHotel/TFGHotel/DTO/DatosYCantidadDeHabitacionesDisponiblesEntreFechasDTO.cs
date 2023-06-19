using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO
    {
        [JsonPropertyName("id_tipo_de_habitacion")]
        public int id_tipo_de_habitacion { get; set; }
        [JsonPropertyName("cantidad_de_habitaciones_disponibles")]
        public int habitaciones_disponibles { get; set; }
        [JsonPropertyName("categoria")]
        public string categoria { get; set; }
        [JsonPropertyName("precio")]
        public decimal precio { get; set; }
        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }
        [JsonPropertyName("img_habitacion_base_64")]
        public string img_habitacion_base_64 { get; set; }
        [JsonPropertyName("tamaño")]
        public int tamaño { get; set; }
        [JsonPropertyName("enlace_url")]
        public string enlace_url { get; set; }
    }
}
