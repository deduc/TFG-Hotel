using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Habitaciones
{
    public interface ITiposDeHabitacionesService
    {
        List<TipoDeHabitacionDTO> GetTiposDeHabitaciones();
        List<DATOS_DE_HABITACIONES_DISPONIBLES> GetDatosDeHabitacionesDisponibles();
        DatosHabitacionDisponibleDTO GetHabitacionById(int id);
        bool DoCheckIfIdTipoHabitacionExists(int idTipoHabitacion);
    }
}
