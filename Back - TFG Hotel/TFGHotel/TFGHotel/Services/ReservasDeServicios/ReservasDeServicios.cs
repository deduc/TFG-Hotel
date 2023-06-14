using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.ReservasDeServicios
{
    public class ReservasDeServicios: IReservasDeServicios
    {
        private FCT10Context _context;

        // constructor
        public ReservasDeServicios(FCT10Context context) {
            this._context = context;
        }

        public List<RESERVAS_DE_SERVICIOS> GetReservasDeServicios()
        {
            return this._context.Reservas_De_Servicios.ToList();
        }

        public async Task AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            RESERVAS_DE_SERVICIOS objMapeado = this.DoCreateObjectByDTO(reservasDeServiciosDTO);
            await _context.Reservas_De_Servicios.AddAsync(objMapeado);
            await _context.SaveChangesAsync();
        }

        private RESERVAS_DE_SERVICIOS DoCreateObjectByDTO(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            RESERVAS_DE_SERVICIOS reserva = new()
            {
                //Id_Reserva_Servicio = reservasDeServiciosDTO.Id_Reserva_Servicio,
                //ID_RESERVA = reservasDeServiciosDTO.Id_Reserva,
                ID_CLIENTE = reservasDeServiciosDTO.Id_Cliente,
                ID_SERVICIO = reservasDeServiciosDTO.Id_Servicio,
            };

            return reserva;
        }

        public async Task<string> DeleteReservasDeServiciosById(int id)
        {
            string returnValue;
            var reserva = this._context.Reservas_De_Servicios.Where( x => x.ID_RESERVA_SERVICIO == id).FirstOrDefault();

            if (reserva == null)
            {
                returnValue = "ERROR: No existe";
            }
            else
            {
                returnValue = "Reserva de servicio eliminada con éxito.";
                _context.Reservas_De_Servicios.Remove(reserva);
                await _context.SaveChangesAsync();
            }

            return returnValue;
        }
    }
}
