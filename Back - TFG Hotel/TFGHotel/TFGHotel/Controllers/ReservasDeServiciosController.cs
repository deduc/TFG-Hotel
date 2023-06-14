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
        public ActionResult<string> AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            string returnValue = "Reserva de servicio añadida correctamente.";

            this._reservasDeServiciosService.AddNewReservasDeServicios(reservasDeServiciosDTO);

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
