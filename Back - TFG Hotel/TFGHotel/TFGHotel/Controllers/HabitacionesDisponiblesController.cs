using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.HabitacionesDisponibles;

namespace TFGHotel.Controllers
{
    [ApiController]
    [Route("api/habitaciones-disponibles")]
    public class HabitacionesDisponiblesController
    {
        private readonly IHabitacionesDisponiblesService _habitacionesDisponiblesService;
        public HabitacionesDisponiblesController(IHabitacionesDisponiblesService habitacionesDisponiblesService)
        {
            this._habitacionesDisponiblesService = habitacionesDisponiblesService;
        }

        [HttpPost]
        [Route("listar-habitaciones-disponibles-entre-fechas")]
        public List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {
            List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> habitacionesDisponibles;

            habitacionesDisponibles = this._habitacionesDisponiblesService.GetHabitacionesDisponiblesEntreFechas(objFechasDto);

            return habitacionesDisponibles;
        }

        // fin clase
    }

    // fin namespace
}
