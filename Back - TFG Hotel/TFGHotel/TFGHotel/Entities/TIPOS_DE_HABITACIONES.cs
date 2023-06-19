namespace TFGHotel.Entities
{
    public class TIPOS_DE_HABITACIONES
    {
        public int ID_TIPO_DE_HABITACION { get; set; }
        public int ID_TIPO_DE_CAMA{ get; set; }
        public string CATEGORIA{ get; set; }
        public string DESCRIPCION { get; set; }
        public string IMG_HABITACION_BASE_64{ get; set; }
        public int TAMAÑO{ get; set; }
        public decimal PRECIO{ get; set; }
        public string ENLACE_URL { get; set; }
    }
}
