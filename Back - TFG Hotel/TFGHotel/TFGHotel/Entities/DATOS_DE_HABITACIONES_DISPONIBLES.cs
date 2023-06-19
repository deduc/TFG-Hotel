namespace TFGHotel.Entities
{
    public class DATOS_DE_HABITACIONES_DISPONIBLES
    {
        public int ID_TIPO_DE_HABITACION{ get; set; }
        public int HABITACIONES_DISPONIBLES{ get; set; }
        public string CATEGORIA { get; set; }
        public decimal PRECIO { get; set; }
        public string DESCRIPCION { get; set; }
        public string IMG_HABITACION_BASE_64{ get; set; }
        public int TAMAÑO { get; set; }
    }
}
