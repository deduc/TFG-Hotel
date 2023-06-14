namespace TFGHotel.Entities
{
    public class DATOS_DE_HABITACIONES_DISPONIBLES
    {
        public int id_tipo_de_habitacion{ get; set; }
        public int habitaciones_disponibles{ get; set; }
        public string categoria { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public string img_habitacion_base_64{ get; set; }
        public int tamaño { get; set; }

    }
}
