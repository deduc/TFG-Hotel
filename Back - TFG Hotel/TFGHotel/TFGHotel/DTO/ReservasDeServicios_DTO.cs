﻿using System.Text.Json.Serialization;

namespace TFGHotel.DTO
{
    public class ReservasDeServicios_DTO
    {
        [JsonPropertyName("Id_Cliente")]
        public int Id_Cliente{ get; set; }
        [JsonPropertyName("Id_Servicio")]
        public int Id_Servicio { get; set; }
    }
}
