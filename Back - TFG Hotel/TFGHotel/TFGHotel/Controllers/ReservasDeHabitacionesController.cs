using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Services.Reservas;


namespace TFGHotel.Controllers
{
    /*
     * Decoradores de clase para indicar 
     *  que es un controlador para una api 
     *  y que la ruta raíz es /api/reservas
     */
    [ApiController]
    [Route("api/reservas-de-habitaciones")]
    public class ReservasDeHabitacionesController: Controller
    {
        private readonly IReservasDeHabitacionesService _reservasService;

        public ReservasDeHabitacionesController(IReservasDeHabitacionesService reservasService)
        {
            _reservasService = reservasService;
        }

        [HttpGet]
        [Route("listar-reservas")]
        public List<ReservasDeHabitacionesDTO> GetReservas()
        {
            return _reservasService.GetReservas();
        }

        [HttpPost]
        [Route("crear-nueva-reserva")]
        public ActionResult<string> AddNewReserva(ReservasDeHabitacionesDTO reservaDTO)
        {
            _reservasService.AddNewReserva(reservaDTO);
            return Ok("Reserva añadida");
        }

        [HttpDelete]
        [Route("borrar-reserva/{id:int}")]
        public ActionResult<string> DeleteReservaById(int id)
        {
            var mensaje = _reservasService.DeleteReservaById(id);
            
            return Ok(mensaje);
        }

        [HttpPut]
        [Route("actualizar-reserva/{id:int}")]
        public ActionResult<string> UpdateReservaById(int id, ReservasDeHabitacionesDTO reservaDTO)
        {
            var mensaje = _reservasService.UpdateReservaById(id, reservaDTO);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("deshabilitar-reserva/{id:int}")]
        public ActionResult<string> DisableReservaById(int id)
        {
            var mensaje = _reservasService.DisableReservaById(id);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("habilitar-reserva/{id:int}")]
        public ActionResult<string> EnableReservaById(int id)
        {
            var mensaje = _reservasService.EnableReservaById(id);

            return Ok(mensaje);
        }
    }
}
