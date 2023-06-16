namespace TFGHotel.DTO
{
    public class DatosYCantidadDeHabitacionesDisponiblesEntreFechas
    {
        public int Id_Tipo_De_Habitacion { get; set; }
        public int Cantidad_De_Habitaciones_Disponibles { get; set; }
        public string Categoria { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public string Img_Habitacion_Base_64 { get; set; }
        public int Tamaño { get; set; }
        public string Enlace_Url { get; set; }
    }
}
