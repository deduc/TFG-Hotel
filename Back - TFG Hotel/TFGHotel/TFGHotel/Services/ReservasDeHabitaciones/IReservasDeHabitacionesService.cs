using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;

namespace TFGHotel.Services.Reservas
{
    public interface IReservasDeHabitacionesService
    {
        List<ReservasDeHabitacionesDTO> GetReservas();
        void AddNewReserva(ReservasDeHabitacionesDTO reservaDTO);
        string DeleteReservaById(int id);
        string UpdateReservaById(int id, ReservasDeHabitacionesDTO reservaDTO);
        string DisableReservaById(int id);
        string EnableReservaById(int id);
    }
}
