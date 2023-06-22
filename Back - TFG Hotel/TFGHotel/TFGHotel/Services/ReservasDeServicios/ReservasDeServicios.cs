using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.ReservasDeServicios
{
    public class ReservasDeServicios: IReservasDeServicios
    {
        private FCT10Context _context;

        public ReservasDeServicios(FCT10Context context) {
            this._context = context;
        }

        public List<RESERVAS_DE_SERVICIOS> GetReservasDeServicios()
        {
            return this._context.Reservas_De_Servicios.ToList();
        }

        public string AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            string returnValue;
            bool semaforoCliente = this.CheckIfIdClienteExists(reservasDeServiciosDTO.Id_Cliente);
            bool semaforoTipoServicio = this.CheckIfIdServicioExists(reservasDeServiciosDTO.Id_Servicio);

            if(semaforoCliente == true && semaforoTipoServicio == true)
            {
                RESERVAS_DE_SERVICIOS reserva = new()
                {
                    ID_CLIENTE = reservasDeServiciosDTO.Id_Cliente,
                    ID_SERVICIO = reservasDeServiciosDTO.Id_Servicio,
                    RESERVA_ACTIVA = 1
                };

                _context.Reservas_De_Servicios.Add(reserva);
                _context.SaveChanges();

                returnValue = "Reserva de servicio creada correctamente.";
            }
            else
            {
                returnValue = "ERROR: No existe un cliente con id " + reservasDeServiciosDTO.Id_Cliente + " y/o un servicio con id " + reservasDeServiciosDTO.Id_Servicio;
            }

            return returnValue;
        }

        public bool CheckIfIdClienteExists(int idCliente) {
            CLIENTES cliente = _context.Clientes
                .Where(x => x.ID_CLIENTE == idCliente)
                .FirstOrDefault();

            if (cliente != null) return true;
            else return false;
        }
        public bool CheckIfIdServicioExists(int idServicio){
            TIPOS_DE_SERVICIOS tipoServicio = _context.Tipos_De_Servicios
                .Where(x => x.ID_SERVICIO == idServicio)
                .FirstOrDefault();

            if (tipoServicio != null) return true;
            else return false;
        }

        private bool ComprobarIdClienteIdServicio(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {

            //Comprobar que el ID del cliente y del servicio existen
            RESERVAS_DE_SERVICIOS reserva = this._context.Reservas_De_Servicios
                .FirstOrDefault(col => col.ID_CLIENTE == reservasDeServiciosDTO.Id_Cliente && col.ID_SERVICIO == reservasDeServiciosDTO.Id_Servicio);

            if(reserva != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        // fin clase
    }
}
