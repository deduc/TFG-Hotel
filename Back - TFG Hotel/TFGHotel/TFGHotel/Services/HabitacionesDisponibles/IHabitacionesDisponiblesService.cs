using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.HabitacionesDisponibles
{
    public interface IHabitacionesDisponiblesService
    {
        List<RESERVAS_DE_HABITACIONES> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto);
        List<int> GetIdHabitacionesDisponibles(FechaInicioFinDTO objFechas);
        List<DatosYCantidadDeHabitacionesDisponiblesEntreFechas> GetDatosDeHabitacionesByIdList(List<int> listaIdsHabitaciones);
    }
}
