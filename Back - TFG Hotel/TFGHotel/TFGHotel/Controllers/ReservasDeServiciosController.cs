using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.Clientes;
using TFGHotel.Services.ReservasDeServicios;
using TFGHotel.Services.Usuarios;

namespace TFGHotel.Controllers
{
    [ApiController]
    [Route("api/reservas-de-servicios")]
    public class ReservasDeServiciosController
    {
        public IReservasDeServicios _reservasDeServiciosService;
        public IClientesService _clientesService;
        public IUsuariosService _usuariosService;
        //GetIdClienteByUsername

        public ReservasDeServiciosController
        (
            IReservasDeServicios reservasDeServiciosService,
            IClientesService clientesService,
            IUsuariosService usuariosService
        )
        {
            this._reservasDeServiciosService = reservasDeServiciosService;
            this._clientesService = clientesService;
            this._usuariosService = usuariosService;
        }

        [HttpGet]
        [Route("listar-reservas-de-servicios")]
        public List<RESERVAS_DE_SERVICIOS> GetReservasDeServicios()
        {
            return this._reservasDeServiciosService.GetReservasDeServicios();
        }

        [HttpPost]
        [Route("crear-reservas-de-servicios")]
        public ActionResult<string> AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            string returnValue;

            returnValue = this._reservasDeServiciosService.AddNewReservasDeServicios(reservasDeServiciosDTO);

            if (returnValue.Length == 0) 
            {
                returnValue = "Reserva de servicio añadida correctamente.";
            }
            else
            {
                returnValue = "ERROR: no se ha podido añadir una reserva de servicio. Es posible que los datos introducidos estén mal." + "\n" + returnValue;
            }

            return returnValue;
        }

        [HttpPost]
        [Route("add-reserva-de-servicio-with-username")]
        public string AddNewReservasDeServiciosWithUsername(ReservaDeServicioWithUsernameIdTipoServicioDTO objReservaDeServicio)
        {
            string returnValue;
            string username = objReservaDeServicio.Username;
            int idServicio = objReservaDeServicio.Id_Servicio;

            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine(username, idServicio);
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            bool semaforoClienteExiste = this._clientesService.DoCheckIfClienteExists(username);

            if(semaforoClienteExiste != true)
            {
                USUARIOS userData = this._usuariosService.GetUserDataByUsername(username);
                this._clientesService.AddNewClienteByUserData(userData);
            }
            
            int idCliente = this._clientesService.GetIdClienteByUsername(username);

            if (idCliente != 0)
            {
                ReservasDeServicios_DTO reservasDeServiciosDTO = new ReservasDeServicios_DTO
                {
                    Id_Cliente = idCliente,
                    Id_Servicio = idServicio
                };
                returnValue = this._reservasDeServiciosService.AddNewReservasDeServicios(reservasDeServiciosDTO);

                return returnValue;
            }
            else
            {
                throw new Exception("El idCliente no pudo ser obtenido");
            }

        }

        [HttpDelete]
        [Route("eliminar-reservas-de-servicios/{id:int}")]
        public Task<string> DeleteReservasDeServiciosById(int id)
        {
            Task<string> returnValue;

            returnValue = this._reservasDeServiciosService.DeleteReservasDeServiciosById(id);

            return returnValue;
        }

        [HttpGet]
        [Route("get-reservas-de-servicios-by-id-cliente")]
        public List<DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES> GetReservasDeServiciosByIdCliente(int idCliente)
        {
            var misReservas = this._reservasDeServiciosService.GetReservasDeServiciosByIdCliente(idCliente);

            return misReservas;
        }

        [HttpGet]
        [Route("cancelar-reserva-de-servicio")]
        public void CancelarReservaDeServicio(int idReservaServicio)
        {
            this._reservasDeServiciosService.CancelarReservaDeServicio(idReservaServicio);
        }


        // fin clase
    }
}
