using Microsoft.AspNetCore.Mvc;
using TFGHotel.DTO;
using TFGHotel.Entities;

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
        
        HABITACIONES GetHabitacionDataByIdTipoHabitacion(int idTipoHabitacion);
        bool ModificarCampoDisponible(HABITACIONES habitacion, int valorCampoDisponible);
        ReservasDeHabitacionesDTO DoBuildReservasDeHabitacionesDTOByDatosCliente(
                    CLIENTES datosCliente,
                    HABITACIONES datosHabitacion,
                    FechaInicioFinDTO objFechas);
        bool DoCheckIfReservaDeHabitacionWasAdded(ReservasDeHabitacionesDTO reserva);
    }
}
