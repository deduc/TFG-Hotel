namespace TFGHotel.DTO
{
    public class DatosHabitacionDisponibleDTO
    {
        public int idtipodehabitacion { get; set; }
        public int habitacionesdisponibles { get; set; }
        public string categoria { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public string imghabitacionbase64 { get; set; }
        public int tamano { get; set; }
    }
}