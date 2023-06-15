namespace TFGHotel.DTO
{
    public class DatosYCantidadDeHabitacionesDisponiblesEntreFechas
    {
        public int ID_TIPO_DE_HABITACION { get; set; }
        public int CANTIDAD_DE_HABITACIONES_DISPONIBLES { get; set; }
        public string CATEGORIA { get; set; }
        public int PRECIO { get; set; }
        public string DESCRIPCION { get; set; }
        public string IMG_HABITACION_BASE_64 { get; set; }
        public int TAMAÑO { get; set; }
        public string ENLACE_URL { get; set; }
    }
}
