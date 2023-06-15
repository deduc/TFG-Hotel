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

        // decorador de metodo. La API recibe una consulta en modo GET
        [HttpGet]
        [Route("listar-usuarios")]
        public List<UsuariosDTO> GetUsers()
        {
            var resultado = _usuariosService.GetUsuarios();
            return resultado;
        }

        // decorador de metodo. La API recibe una consulta en modo POST
        [HttpPost]
        [Route("crear-nuevo-usuario")]
        public ActionResult<List<string>> AddNewUser(UsuariosDTO usuarioDTO)
        {
            var errorsList = _usuariosService.AddNewUser(usuarioDTO);
            
            if(errorsList.Count == 0)
            {
                errorsList.Add("Usuario insertado con éxito");
                return Ok(Json(errorsList));
            }

            return BadRequest(Json(errorsList));
        }


        // decorador de metodo. La API recibe una consulta en modo POST para eliminar usuarios, filtrando por ID en el cuerpo de la petición.
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

    }
}