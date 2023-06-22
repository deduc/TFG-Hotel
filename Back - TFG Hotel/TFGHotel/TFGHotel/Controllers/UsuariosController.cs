// namespace del que importo la clase Controller
using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Entities;
// namespace del que importo la interfaz IusuariosService
using TFGHotel.Services.Usuarios;


namespace TFGHotel.Controllers
{
    /*
     * Decoradores de clase para indicar 
     *  que es un controlador para una api 
     *  y que la ruta raíz es /api/usuarios
     */
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController: Controller
    {
        private IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        [Route("listar-usuarios")]
        public List<UsuariosDTO> GetUsers()
        {
            var resultado = _usuariosService.GetUsuarios();
            return resultado;
        }

        [HttpPost]
        [Route("crear-nuevo-usuario")]
        public List<string> AddNewUser(UsuariosDTO usuarioDTO)
        {
            var errorsList = _usuariosService.AddNewUser(usuarioDTO);
            
            if(errorsList.Count == 0)
            {
                return errorsList;
            }

            return errorsList;
        }


        [HttpDelete("eliminar-usuario")]
        public ActionResult DeleteUserById(int idUsuarioABorrar)
        {
            string returnValue = "ERROR: El ID introducido no es válido";

            if (_usuariosService.DeleteUserById(idUsuarioABorrar))
            {
                returnValue = "Usuario borrado con éxito.";
                return Ok(Json(returnValue));
            }

            return BadRequest(Json(returnValue));
        }



        [HttpPost]
        [Route("login")]
        public UsuarioLoginDTO LoginUsuario(UsuarioLoginDTO usuario)
        {
            var resultado = _usuariosService.LoginUsuario(usuario);

            return resultado;
        }

        [HttpPost]
        [Route("comprobar-si-login-correcto")]
        public Boolean ComprobarSiLoginCorrecto(UsuarioLoginDTO datosLogin) {
            return _usuariosService.ComprobarSiLoginCorrecto(datosLogin);
        }

        [HttpPost]
        [Route("obtener-datos-de-usuario-by-email")]
        public USUARIOS GetUserDataByEmail(UserEmailObjectDTO userEmailObj)
        {
            string email = userEmailObj.Email;
            
            return _usuariosService.GetUserDataByEmail(email);
        }

        [HttpPost]
        [Route("cambiar-contrasena")]
        public string DoChangeUserPassword(DoChangeUserPasswordDTO obj)
        {
            bool semaforo;
            string value;


            if (obj.NewPassword.Length < 8) return "ERROR: La contraseña no puede ser menor o igual a 8 caracteres.";
            if (obj.OldPassword.Length < 8) return "ERROR: La contraseña antigua no puede ser menor o igual a 8 caracteres.";
            if (obj.Username.Length == 0) return "ERROR: El campo del usuario es obligatorio, no puedes ponerlo vacío.";


            semaforo = this._usuariosService.DoChangeUserPassword(obj);

            if(semaforo == true)
            {
                value = "La contraseña del usuario ha sido cambiada.";
            }
            else
            {
                value = "ERROR: El usuario y/o la contraseña no coinciden.";
            }

            return value;

            // fin metodo
        }


        // fin clase
    }
}