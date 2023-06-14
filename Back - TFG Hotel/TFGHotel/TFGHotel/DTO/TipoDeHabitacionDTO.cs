namespace TFGHotel.DTO
{
    public class TipoDeHabitacionDTO
    {
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int Tamaño { get; set; }
        public string imgHabitacionBase64 { get; set; }
        public decimal Precio { get; set; }
        public string enlace_url { get; set; }
    }
}
