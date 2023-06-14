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
        private readonly IUsuariosService _usuariosService;
        private string responseText;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // --- GET ---
        // decoradores de mi endpoint GetUsersFromDatabase
        [HttpGet]
        [Route("listar-usuarios")]
        public List<UsuariosDTO> GetUsers()
        {
            var resultado = _usuariosService.GetUsuarios();
            return resultado;
        }
        // --- FIN GET ---


        // --- POST ---
        // decorador de metodo para hacer una consulta a la API en modo POST
        [HttpPost]
        [Route("crear-nuevo-usuario")]
        public List<string> Post(UsuariosDTO usuarioDTO)
        {
            var errorsList = _usuariosService.AddNewUser(usuarioDTO);
            int errorsNumber = errorsList.Count;

            return errorsList;
        }
        // --- FIN POST ---


        // --- METODOS DELETE ---
        // Decorador para eliminar usuarios filtrando por ID en la url
        [HttpDelete("eliminar-usuario/{id:int}")]
        public ActionResult DeleteUserById(int idUsuarioABorrar)
        {
            this.responseText = "ERROR: El ID introducido no es válido";

            if (_usuariosService.DeleteUserById(idUsuarioABorrar))
            {
                this.responseText = "Usuario borrado con éxito.";
                return Ok(Json(responseText));
            }

            return BadRequest(Json(responseText));
        }
        // --- FIN METODOS DELETE ---



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