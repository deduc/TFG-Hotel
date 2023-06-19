using TFGHotel.ClasesAuxiliares;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.HabitacionesDisponibles
{
    public interface IHabitacionesDisponiblesService
    {
        List<DatosYCantidadDeHabitacionesDisponiblesEntreFechasDTO> GetHabitacionesDisponiblesEntreFechas(FechaInicioFinDTO objFechasDto);
    }
}
