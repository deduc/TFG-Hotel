using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.ReservasDeServicios
{
    public interface IReservasDeServicios
    {
        List<RESERVAS_DE_SERVICIOS> GetReservasDeServicios();
        Task AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO);
        Task<string> DeleteReservasDeServiciosById(int id);
    }
}
