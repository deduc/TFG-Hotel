using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.Habitaciones;

namespace TFGHotel.Controllers
{
    [ApiController]
    [Route("api/tipos-de-habitaciones")]
    public class TiposDeHabitacionesController: Controller
    {
        private readonly ITiposDeHabitacionesService _tiposDeHabitacionesService;

        public TiposDeHabitacionesController(ITiposDeHabitacionesService habitacionesService)
        {
            _tiposDeHabitacionesService = habitacionesService;
        }

        [HttpGet]
        [Route("listar-tipos-de-habitaciones")]
        public List<TipoDeHabitacionDTO> GetInfoFromAllHabitaciones()
        {
            return this._tiposDeHabitacionesService.GetTiposDeHabitaciones();
        }

        [HttpGet]
        [Route("listar-datos-de-habitaciones-disponibles")]
        public List<DATOS_DE_HABITACIONES_DISPONIBLES> GetHabitacionesDisponibles()
        {
            return this._tiposDeHabitacionesService.GetDatosDeHabitacionesDisponibles();
        }


        [HttpPost]
        [Route("listar-habitacion-por-id")]
        public DATOS_DE_HABITACIONES_DISPONIBLES GetHabitacionById(int id)
        {
            return this._tiposDeHabitacionesService.GetHabitacionById(id);
        }

        //fin clase
    }

    // fin namespace
}
