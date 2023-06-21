using Microsoft.EntityFrameworkCore;
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

            return habitacionesDisponibles;

        }

        public DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO FiltrarHabitacionPorTipoDeHabitacion(List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> listaHabitaciones, int idTipoHabitacion)
        {
            int idFiltrar = idTipoHabitacion;
            List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> resultadosFiltrados;


            resultadosFiltrados = listaHabitaciones
            .Where(d => d.id_tipo_de_habitacion == idFiltrar)
            .ToList();

            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            Console.WriteLine(resultadosFiltrados.Count);
            Console.WriteLine(resultadosFiltrados[0].id_tipo_de_habitacion);
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

            if (resultadosFiltrados.Count == 1)
            {
                return resultadosFiltrados[0];
            }
            else
            {
                // Retorno un objeto vacío
                return new DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO
                { 
                    id_tipo_de_habitacion = 0, 
                    habitaciones_disponibles = 0, 
                    categoria = "", 
                    descripcion = "", 
                    enlace_url = "", 
                    img_habitacion_base_64 = "", 
                    precio = 0, 
                    tamaño = 0 
                };
            }

            // fin metodo

        }

        // fin clase
    }

    // fin namespace
}
