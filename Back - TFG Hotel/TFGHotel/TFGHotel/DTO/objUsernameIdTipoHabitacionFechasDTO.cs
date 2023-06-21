using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class objUsernameIdTipoHabitacionFechasDTO
    {
        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("idTipoHabitacion")]
        public int idTipoHabitacion { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonPropertyName("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonPropertyName("FechaFin")]
        public DateTime FechaFin { get; set; }
    }

    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTime(out DateTime dateTime))
            {
                return dateTime.Date;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }
}
