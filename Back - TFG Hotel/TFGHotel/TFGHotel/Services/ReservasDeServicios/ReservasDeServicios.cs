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

        public async Task<string> AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO)
        {
            /*
             * Comprobar que el ID del cliente y del servicio existen
             * Si existen:
             *      crear objeto RESERVAS_DE_SERVICIOS
             *      añadir fila de forma asincrona
             *      guardar cambios de forma asincrona
             * Si no:
             *      mensaje de error
             */
            string returnValue;
            bool semaforo = this.ComprobarIdClienteIdServicio(reservasDeServiciosDTO);

            if(semaforo == true)
            {
                RESERVAS_DE_SERVICIOS reserva = new()
                {
                    //Id_Reserva_Servicio = reservasDeServiciosDTO.Id_Reserva_Servicio,
                    //ID_RESERVA = reservasDeServiciosDTO.Id_Reserva,
                    ID_CLIENTE = reservasDeServiciosDTO.Id_Cliente,
                    ID_SERVICIO = reservasDeServiciosDTO.Id_Servicio,
                };

                await _context.Reservas_De_Servicios.AddAsync(reserva);
                await _context.SaveChangesAsync();

                returnValue = "Reserva de servicio creada correctamente.";
            }
            else
            {
                returnValue = "ERROR: No existe un cliente con id " + reservasDeServiciosDTO.Id_Cliente + " y/o un servicio con id " + reservasDeServiciosDTO.Id_Servicio;
            }

            return returnValue;
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
    }
}
