using Microsoft.AspNetCore.Mvc;


namespace TFGHotel.Controllers
{
    /*
     * Decoradores de clase para indicar 
     *  que es un controlador para una api 
     *  y que la ruta raíz es /api/NombreController
     */
    [ApiController]
    [Route("api/NombreController")]
    public class NombreController: Controller
    {
        public NombreController()
        // parametros   INombreServicio nombreService, NombreUtilidades nombre
        {
        }

        // --- METODOS GET ---
        // decoradores de mi endpoint GetUsersFromDatabase
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<string>> Get()
        {
            //var resultado = _usuariosService.GetUsuarios();
            return Ok("var resultado");
        }
        // --- FIN METODOS GET ---

        // --- METODOS POST ---
        // decorador de metodo para hacer una consulta a la API en modo POST
        [HttpPost]
        [Route("añadir")]
        public ActionResult Post()
        // Parametros   NombreDTO nombreDto
        {
            //if (condicion)
            //{
            //    return BadRequest();
            //}

            return Ok("Not implemented yet()");
        }
        // --- FIN METODOS POST ---


        // --- METODOS DELETE ---
        // Decorador para eliminar usuarios filtrando por ID en la url
        [HttpDelete("eliminar-usuario/{id:int}")]
        public ActionResult DeleteUserById(int idUsuarioABorrar)
        {
            //if (_usuariosService.DeleteUserById(idUsuarioABorrar))
            //{
            //    return Ok();
            //}

            //return BadRequest("ERROR: El ID introducido no es válido.");

            // borrar
            return Ok();
        }
        // --- FIN METODOS DELETE ---
    }
}