using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.HabitacionesDisponibles
{
    public class HabitacionesDisponiblesService: IHabitacionesDisponiblesService
    {
        private FCT10Context _context;

        public HabitacionesDisponiblesService(FCT10Context context)
        {
            _context = context;
        }

        public List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {
            List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> datosYCantidadDeHabitacionesDisponibles = new List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> { };
            List<int> listaIdsHabitaciones;

            listaIdsHabitaciones = this.GetIdHabitacionesDisponibles(objFechasDto);
            datosYCantidadDeHabitacionesDisponibles = this.GetDatosDeHabitacionesByIdList(listaIdsHabitaciones);

            return datosYCantidadDeHabitacionesDisponibles;
        }

        // Método que devuelve una lista de IDs de habitaciones disponibles entre las fechas obtenidas a partir de un objeto que contiene 2 fechas.
        public List<int> GetIdHabitacionesDisponibles(FechaInicioFinDTO objFechas)
        {
            List<int> idHabitaciones = new List<int>();

            idHabitaciones = _context.Reservas_De_Habitaciones
                // no quiero obtener las habiaciones que cumplan con lo siguiente:
                .Where(x => ! _context.Reservas_De_Habitaciones
                    .Where(r => (r.FECHA_INICIO <= objFechas.FechaInicio && r.FECHA_FIN >= objFechas.FechaInicio) )
                    .Select(r => r.ID_HABITACION)
                    .Contains(x.ID_HABITACION))
                .Select(x => x.ID_HABITACION)
                .ToList();

            return idHabitaciones;

            // fin metodo
        }

        // TODO: MEJORA ESTO JJAJAJAJAJJAJA
        public List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> GetDatosDeHabitacionesByIdList(List<int> listaIdsHabitaciones)
        {
            DateTime FECHA_INICIO_RESERVA = new DateTime(2024, 6, 2);
            DateTime FECHA_FIN_RESERVA = new DateTime(2024, 6, 4);
            List<int> habitacionIDs = new List<int> { 1, 2, 9, 18, 20 };

            var habitacionesDisponibles = _context.Habitaciones
                .Where(habitacion => habitacionIDs.Contains(habitacion.ID_HABITACION))
                .Join(_context.TiposDeHabitaciones,
                      habitacion => habitacion.ID_TIPO_DE_HABITACION,
                      tipoHabitacion => tipoHabitacion.ID_TIPO_DE_HABITACION,
                      (habitacion, tipoHabitacion) => new { Habitacion = habitacion, TipoHabitacion = tipoHabitacion })
                .GroupBy(x => new
                {
                    x.Habitacion.ID_TIPO_DE_HABITACION,
                    x.TipoHabitacion.CATEGORIA,
                    x.TipoHabitacion.PRECIO,
                    x.TipoHabitacion.DESCRIPCION,
                    x.TipoHabitacion.IMG_HABITACION_BASE_64,
                    x.TipoHabitacion.TAMAÑO,
                    x.TipoHabitacion.ENLACE_URL
                })
                .Select(g => new IdHabitacionYCantidad
                {
                    ID_TIPO_DE_HABITACION = g.Key.ID_TIPO_DE_HABITACION,
                    CANTIDAD_DE_HABITACIONES_DISPONIBLES = g.Count(),
                    CATEGORIA = g.Key.CATEGORIA,
                    PRECIO = g.Key.PRECIO,
                    DESCRIPCION = g.Key.DESCRIPCION,
                    IMG_HABITACION_BASE_64 = g.Key.IMG_HABITACION_BASE_64,
                    TAMAÑO = g.Key.TAMAÑO,
                    ENLACE_URL = g.Key.ENLACE_URL
                })
                .ToList();

        }

        // fin clase
    }

    // fin namespace
}
