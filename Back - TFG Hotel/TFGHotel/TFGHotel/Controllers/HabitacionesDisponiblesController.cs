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
        [Route("obtener-habitaciones-disponibles-entre-fechas")]
        public List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {
            if(objFechasDto.FechaInicio <= objFechasDto.FechaFin)
            {
                return this._habitacionesDisponiblesService.GetHabitacionesDisponiblesEntreFechas(objFechasDto);
            }
            else
            {
                throw new Exception("ERROR: FechaInicio no puede ser mayor a FechaFin");
            }
        }

        [HttpPost]
        [Route("obtener-datos-de-habitacion-disponible-entre-fechas")]
        public DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO GetDatosDeHabitacionDisponibleEntreFechas(MezclaDeObjetoFechasYObjetoIdTipoHabitacion objFechasIdHabitacion)
        {
            FechaInicioFinDTO objFechas = objFechasIdHabitacion.objFechasDto;
            int idTipoHabitacion = objFechasIdHabitacion.idTipoHabitacion.IdHabitacion;
            
            Console.WriteLine("Recibido el objeto");
            Console.WriteLine(objFechasIdHabitacion.objFechasDto.FechaInicio);
            Console.WriteLine(objFechasIdHabitacion.objFechasDto.FechaFin);
            Console.WriteLine(objFechasIdHabitacion.idTipoHabitacion.IdHabitacion);
            
            List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> listaHabitacionesDisponibles = this._habitacionesDisponiblesService.GetHabitacionesDisponiblesEntreFechas(objFechas);

            return this._habitacionesDisponiblesService.FiltrarHabitacionPorTipoDeHabitacion(listaHabitacionesDisponibles, idTipoHabitacion);
        }


        // fin clase
    }

    // fin namespace
}
