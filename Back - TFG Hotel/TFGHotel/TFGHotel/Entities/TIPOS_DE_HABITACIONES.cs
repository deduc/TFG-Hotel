namespace TFGHotel.Entities
{
    public class TIPOS_DE_HABITACIONES
    {
        public int id_tipo_de_habitacion { get; set; }
        public int id_tipo_de_cama{ get; set; }
        public string categoria{ get; set; }
        public string descripcion { get; set; }
        public string img_habitacion_base_64{ get; set; }
        public int tamaño{ get; set; }
        public decimal precio{ get; set; }
        public string Enlace_Url { get; set; }
    }
}
