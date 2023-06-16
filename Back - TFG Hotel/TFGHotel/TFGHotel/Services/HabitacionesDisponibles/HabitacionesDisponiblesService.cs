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

        public List<HabitacionesIdYCantidadDisponible> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto)
        {
            List<int> idHabitacionesDisponibles;
            List<HabitacionesIdYCantidadDisponible> habitacionesIdYCantidadDisponible;


            idHabitacionesDisponibles = this.GetIDsHabitacionesDisponibles(objFechasDto);
            habitacionesIdYCantidadDisponible = this.obtenerIdTipoHabitacionYCantidad(idHabitacionesDisponibles);

            return habitacionesIdYCantidadDisponible;
        }

        public List<int> GetIDsHabitacionesDisponibles(FechaInicioFinDTO objFechasDto)
        {
            DateTime today = DateTime.Today;
            DateTime fechaInicio = objFechasDto.FechaInicio;
            DateTime fechaFin = objFechasDto.FechaFin;

            return _context.Reservas_De_Habitaciones
                .Where(x => (
                        fechaFin < x.FECHA_INICIO
                    ||  fechaInicio > x.FECHA_FIN
                    &&  fechaInicio < x.FECHA_INICIO
                ))
                .Select(s => s.ID_HABITACION)
                .ToList();
        }

        public List<HabitacionesIdYCantidadDisponible> obtenerIdTipoHabitacionYCantidad(List<int> idHabitacionesDisponibles)
        {
            List<HabitacionesIdYCantidadDisponible> r = new List<HabitacionesIdYCantidadDisponible>();


            r = _context.Habitaciones
                .Where(x => idHabitacionesDisponibles.Contains(x.ID_HABITACION))
                .GroupBy(i => i.ID_TIPO_DE_HABITACION)
                        .Select(g => new HabitacionesIdYCantidadDisponible
                        {
                            ID_TIPO_DE_HABITACION = g.Key,
                            CantidadDisponible = g.Count()
                        })
                        .OrderBy(x => x.ID_TIPO_DE_HABITACION).ToList();
            return r;
        }


        // fin clase
    }

    // fin namespace
}
