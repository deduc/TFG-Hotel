using TFGHotel.DTO;

namespace TFGHotel.Services.HabitacionesDisponibles
{
    public interface IHabitacionesDisponiblesService
    {
        List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto);

        DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO FiltrarHabitacionPorTipoDeHabitacion(List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> listaHabitaciones, int idTipoHabitacion);
    }
}
