namespace TFGHotel.ClasesAuxiliares
{
    public class DatosYCantidadDeHabitaciones
    {
        public int ID_TIPO_DE_HABITACION { get; set; }
        public int ? CANTIDAD_DISPONIBLE { get; set; }
        public string CATEGORIA { get; set; }
        public decimal PRECIO { get; set; }
        public string DESCRIPCION { get; set; }
        public string IMG_HABITACION_BASE_64 { get; set; }
        public int TAMAÑO { get; set; }
        public string ENLACE_URL { get; set; }
    }
}
