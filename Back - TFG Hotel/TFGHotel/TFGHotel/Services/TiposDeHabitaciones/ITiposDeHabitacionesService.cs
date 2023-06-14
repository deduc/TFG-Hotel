using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Habitaciones
{
    public interface ITiposDeHabitacionesService
    {
        //List<> GetHabitacionesBetween2Dates(interfaz 2 fechas);
        List<TipoDeHabitacionDTO> GetTiposDeHabitaciones();
        List<DATOS_DE_HABITACIONES_DISPONIBLES> GetDatosDeHabitacionesDisponibles();

        DATOS_DE_HABITACIONES_DISPONIBLES GetHabitacionById(int id);

    }
}
