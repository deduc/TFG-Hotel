using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.ReservasDeServicios;

namespace TFGHotel.Controllers
{
    [ApiController]
    [Route("api/reservas-de-servicios")]
    public class ReservasDeServiciosController
    {
        public IReservasDeServicios _reservasDeServiciosService;

        public ReservasDeServiciosController(IReservasDeServicios reservasDeServiciosService)
        {
            this._reservasDeServiciosService = reservasDeServiciosService;
        }

        [HttpGet]
        [Route("listar-reservas-de-servicios")]
        public List<RESERVAS_DE_SERVICIOS> GetReservasDeServicios()
        {
            return this._reservasDeServiciosService.GetReservasDeServicios();
        }

        [HttpPost]
        [Route("crear-reservas-de-servicios")]
        public async Task<ActionResult<string>> AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            string returnValue;
            bool semaforo;

            returnValue = await this._reservasDeServiciosService.AddNewReservasDeServicios(reservasDeServiciosDTO);

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

        [HttpDelete]
        [Route("eliminar-reservas-de-servicios/{id:int}")]
        public Task<string> DeleteReservasDeServiciosById(int id)
        {
            Task<string> returnValue;

            returnValue = this._reservasDeServiciosService.DeleteReservasDeServiciosById(id);

            return returnValue;
        }
    }
}
