using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class MezclaDeObjetoFechasYObjetoIdTipoHabitacion
    {
        [JsonPropertyName("objFechasDto")]
        public FechaInicioFinDTO objFechasDto { get; set; }
        [JsonPropertyName("idTipoHabitacion")]
        public IdTipoHabitacionDTO idTipoHabitacion { get; set; }
    }
}