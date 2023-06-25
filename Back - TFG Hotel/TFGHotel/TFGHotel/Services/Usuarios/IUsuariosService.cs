using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Usuarios
{
    public interface IUsuariosService
    {
        List<UsuariosDTO> GetUsuarios();
        public List<string> AddNewUser(UsuariosDTO usuarioDTO);
        bool DeleteUserById(int idUsuarioABorrar);
        UsuarioLoginDTO LoginUsuario(UsuarioLoginDTO usuario);
        Boolean ComprobarSiLoginCorrecto(UsuarioLoginDTO datosLogin);
        USUARIOS GetUserDataByEmail(string email);
        USUARIOS GetUserDataByUsername(string username);
        bool DoCheckIfUserExists(string username);
        bool DoChangeUserPassword(DoChangeUserPasswordDTO obj);
        bool CambiarFotoPerfilUsuario(UsernameFotoPerfilBase64DTO usernameFotoPerfilObj);
        bool ComprobarSiUsuarioEsAdministrador(UserEmailObjectDTO email);
    }
}
