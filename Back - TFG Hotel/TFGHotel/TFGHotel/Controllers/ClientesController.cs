using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Entities;
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

        [HttpPost]
        [Route("crear-cliente-by-user-data")]
        public string AddNewClienteByUserData(USUARIOS datosUsuario)
        {
            bool semaforo;
            string returnValue;
            

            semaforo = this._clientesService.AddNewClienteByUserData(datosUsuario);

            if(semaforo != true)
            {
                returnValue = "ERROR: No se ha podido añadir el cliente debido a un error desconocido.";
            }
            else
            {
                returnValue = "Cliente añadido con exito.";
            }
            
            
            return returnValue;
        }

        [HttpPost]
        [Route("obtener-datos-cliente-by-username")]
        public CLIENTES GetDatosDeClienteWithUsername(UsernameObjectDTO usernameDTO)
        {
            CLIENTES datosCliente = this._clientesService.GetDatosClienteByUsername(usernameDTO.Username);

            return datosCliente;
        }

        // fin clase
    }
}
