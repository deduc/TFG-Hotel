namespace TFGHotel.DTO
{
    public class ReservasDeHabitacionesDTO
    {
        public int Id_Cliente { get; set; }
        public int Id_Habitacion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}
