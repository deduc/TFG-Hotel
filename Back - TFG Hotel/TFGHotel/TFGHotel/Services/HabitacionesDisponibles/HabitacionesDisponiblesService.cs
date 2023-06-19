using TFGHotel.ClasesAuxiliares;
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

        public List<DatosYCantidadDeHabitaciones> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {
            DateTime fechaInicio = objFechasDto.FechaInicio;
            DateTime fechaFin = objFechasDto.FechaFin;

            // Comienzo esta select desde la tabla Habitaciones
            List<DatosYCantidadDeHabitaciones> habitacionesDisponibles = _context.Habitaciones
                // Hago left join en el sql para obtener datos de la tabla Tipos_de_habitaciones
                .GroupJoin(
                    _context.Tipos_De_Habitaciones,
                    h => h.ID_TIPO_DE_HABITACION,
                    t => t.id_tipo_de_habitacion,
                    (h, tipoHabitacionJoin) => new { Habitacion = h, TipoHabitacionJoin = tipoHabitacionJoin }
                 )
                // Select de elementos de las 2 tablas que nipu de cómo funciona
                .SelectMany(
                    x => x.TipoHabitacionJoin.DefaultIfEmpty(),
                    (x, t) => new { x.Habitacion, TipoHabitacion = t }
                )
                // Equivalente al operador NOT IN (listaNumeros) de sql server
                .Where(x => !_context.Reservas_De_Habitaciones
                .Any(r =>
                    r.ID_HABITACION == x.Habitacion.ID_HABITACION 
                    &&
                    (
                        fechaFin < r.FECHA_INICIO 
                        || fechaInicio > r.FECHA_FIN
                    ) 
                    &&
                    fechaInicio < fechaFin
                    )
                )
                .Where(x => fechaInicio < fechaFin)
                // Agrupo los datos de salida 
                .GroupBy(x => new
                    {
                        x.Habitacion.ID_TIPO_DE_HABITACION,
                        x.TipoHabitacion.categoria,
                        x.TipoHabitacion.precio,
                        x.TipoHabitacion.descripcion,
                        x.TipoHabitacion.img_habitacion_base_64,
                        x.TipoHabitacion.tamaño,
                        x.TipoHabitacion.Enlace_Url
                    }
                )
                // Select de los datos de salida agrupados
                .Select(g => new DatosYCantidadDeHabitaciones
                    {
                        ID_TIPO_DE_HABITACION = g.Key.ID_TIPO_DE_HABITACION,
                        CANTIDAD_DISPONIBLE = g.Count(),
                        CATEGORIA = g.Key.categoria,
                        PRECIO = g.Key.precio,
                        DESCRIPCION = g.Key.descripcion,
                        IMG_HABITACION_BASE_64 = g.Key.img_habitacion_base_64,
                        TAMAÑO = g.Key.tamaño,
                        ENLACE_URL = g.Key.Enlace_Url
                    }
                )
                .ToList();

            return habitacionesDisponibles;

        }

        // fin clase
    }

    // fin namespace
}
