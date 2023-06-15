namespace TFGHotel.Entities
{
    public class RESERVAS_DE_HABITACIONES
    {
        public int ID_RESERVA_HABITACION { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_HABITACION { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public int RESERVA_ACTIVA { get; set; }
        //public decimal PRECIO_TOTAL { get; set; }
    }
}
