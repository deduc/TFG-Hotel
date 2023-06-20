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

        UsuariosDTO GetUserData(UserEmailObjectDTO userEmailObj);

        USUARIOS GetUserDataByUsername(string username);
    }
}
