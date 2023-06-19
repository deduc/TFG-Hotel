using Microsoft.EntityFrameworkCore;
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

        public List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {
            DateTime fechaInicio = objFechasDto.FechaInicio;
            DateTime fechaFin = objFechasDto.FechaFin;

            List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> habitacionesDisponibles = (
            from H in _context.Habitaciones
            join T in _context.Tipos_De_Habitaciones on H.ID_TIPO_DE_HABITACION equals T.ID_TIPO_DE_HABITACION
            where ! (
                from R in _context.Reservas_De_Habitaciones
                    where
                            fechaFin < R.FECHA_INICIO ||  
                            fechaInicio > R.FECHA_FIN ||  
                            (   
                                fechaInicio < R.FECHA_FIN && 
                                fechaFin > R.FECHA_INICIO
                            )
                    select R.ID_HABITACION
                    )
                    .Contains(H.ID_HABITACION)
                && fechaInicio < fechaFin
            group new { H, T } by new 
            {
                H.ID_TIPO_DE_HABITACION,
                T.CATEGORIA,
                T.PRECIO,
                T.DESCRIPCION,
                T.IMG_HABITACION_BASE_64,
                T.TAMAÑO,
                T.ENLACE_URL
            } into g
            select new DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO
            {
                id_tipo_de_habitacion = g.Key.ID_TIPO_DE_HABITACION,
                habitaciones_disponibles = g.Count(),
                categoria = g.Key.CATEGORIA,
                precio = g.Key.PRECIO,
                descripcion = g.Key.DESCRIPCION,
                img_habitacion_base_64 = g.Key.IMG_HABITACION_BASE_64,
                tamaño = g.Key.TAMAÑO,
                enlace_url = g.Key.ENLACE_URL
            }
            ).ToList();



            //// Comienzo esta select desde la tabla Habitaciones
            //List<DatosDeHabitacionesDisponiblesDTO> habitacionesDisponibles = _context.Habitaciones
            //    // Hago left join en el sql para obtener datos de la tabla Tipos_de_habitaciones
            //    .GroupJoin(
            //        _context.Tipos_De_Habitaciones,
            //        h => h.ID_TIPO_DE_HABITACION,
            //        t => t.ID_TIPO_DE_HABITACION,
            //        (h, tipoHabitacionJoin) => new { Habitacion = h, TipoHabitacionJoin = tipoHabitacionJoin }
            //     )
            //    // Select de elementos de las 2 tablas que nipu de cómo funciona
            //    .SelectMany(
            //        x => x.TipoHabitacionJoin.DefaultIfEmpty(),
            //        (x, t) => new { x.Habitacion, TipoHabitacion = t }
            //    )
            //    // Equivalente al operador NOT IN (listaNumeros) de sql server
            //    .Where(x => !_context.Reservas_De_Habitaciones
            //    .Any(r =>
            //        r.ID_HABITACION == x.Habitacion.ID_HABITACION 
            //        &&                    (
            //            fechaFin < r.FECHA_INICIO 
            //            || fechaInicio > r.FECHA_FIN
            //        ) 
            //        &&
            //            fechaInicio < fechaFin
            //        )
            //    )
            //    .Where(x => fechaInicio < fechaFin)
            //    // Agrupo los datos de salida 
            //    .GroupBy(x => new
            //        {
            //            x.Habitacion.ID_TIPO_DE_HABITACION,
            //            x.TipoHabitacion.CATEGORIA,
            //            x.TipoHabitacion.PRECIO,
            //            x.TipoHabitacion.DESCRIPCION,
            //            x.TipoHabitacion.IMG_HABITACION_BASE_64,
            //            x.TipoHabitacion.TAMAÑO,
            //            x.TipoHabitacion.ENLACE_URL
            //        }
            //    )
            //    // Select de los datos de salida agrupados
            //    .Select(g => new DatosDeHabitacionesDisponiblesDTO
            //    {
            //            id_tipo_de_habitacion = g.Key.ID_TIPO_DE_HABITACION,
            //            habitaciones_disponibles = g.Count(),
            //            categoria = g.Key.CATEGORIA,
            //            precio = g.Key.PRECIO,
            //            descripcion = g.Key.DESCRIPCION,
            //            img_habitacion_base_64 = g.Key.IMG_HABITACION_BASE_64,
            //            tamaño = g.Key.TAMAÑO,
            //        }
            //    )
            //    .ToList();

            return habitacionesDisponibles;

        }

        // fin clase
    }

    // fin namespace
}
