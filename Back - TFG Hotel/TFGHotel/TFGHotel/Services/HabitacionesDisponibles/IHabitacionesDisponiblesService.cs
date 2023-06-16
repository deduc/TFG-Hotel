using TFGHotel.ClasesAuxiliares;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.HabitacionesDisponibles
{
    public interface IHabitacionesDisponiblesService
    {
        List<HabitacionesIdYCantidadDisponible> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto);
        List<int> GetIDsHabitacionesDisponibles(FechaInicioFinDTO objFechasDto);
        List<HabitacionesIdYCantidadDisponible> obtenerIdTipoHabitacionYCantidad(List<int> idHabitacionesDisponibles);
    }
}
