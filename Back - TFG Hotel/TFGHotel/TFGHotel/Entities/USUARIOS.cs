namespace TFGHotel.Entities
{
    public class USUARIOS 
    {
        public int ID_USUARIO { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string DNI { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string PASS { get; set; }
        public string FOTO_DE_PERFIL_BASE_64 { get; set; }
        public bool ADMINISTRADOR { get; set; }
        public bool USUARIO_ACTIVO { get; set; }
    }
}
