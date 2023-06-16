using Microsoft.AspNetCore.Mvc;
using TFGHotel.ClasesAuxiliares;
using TFGHotel.DTO;
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
        [Route("obtener-id-tipo-habitacion-y-cantidad")]
        public List<HabitacionesIdYCantidadDisponible> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {

            return this._habitacionesDisponiblesService.GetHabitacionesDisponiblesEntreFechas(objFechasDto);
        }


        // fin clase
    }

    // fin namespace
}
