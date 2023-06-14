using Microsoft.AspNetCore.Mvc;
using TFGHotel.Services.Clientes;

namespace TFGHotel.Controllers
{
    /*
     * Decoradores de clase para indicar 
     *  que es un controlador para una api 
     *  y que la ruta raíz es /api/clientes
     */
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController: Controller
    {
        private readonly IClientesService _clientesService;
        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // decoradores de mi endpoint GetUsersFromDatabase
        [HttpGet]
        [Route("listar-clientes")]
        public ActionResult<string> GetClientes()
        {
            var resultado = this._clientesService.GetClientes();
            return Ok(resultado);
        }
    }
}
