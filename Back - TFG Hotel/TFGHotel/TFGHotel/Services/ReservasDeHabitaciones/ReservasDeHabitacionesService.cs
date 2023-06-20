using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.Clientes;

namespace TFGHotel.Services.Reservas
{
    public class ReservasDeHabitacionesService: IReservasDeHabitacionesService
    {
        public FCT10Context _context { get; set; }
        
        // constructor
        public ReservasDeHabitacionesService
            (
                FCT10Context context
            )
        {
            _context = context;
        }

        public List<ReservasDeHabitacionesDTO> GetReservas()
        {
            // obtengo una lista de las reservas activas
            List<RESERVAS_DE_HABITACIONES> reservasList = this.SelectReservasActivas();

            // retorno esta lista de objetos RESERVAS_DE_HABITACIONES convertida a una lista de objetos ReservaDTO
            return reservasList.Select(s => new ReservasDeHabitacionesDTO()
            {
                Id_Habitacion = s.ID_HABITACION,
                Id_Cliente = s.ID_CLIENTE,
                //Nombre_Cliente = s.Nombre_Cliente,
                Fecha_Inicio = s.FECHA_INICIO,
                Fecha_Fin = s.FECHA_FIN,
                // TODO: obtener los servicios y habitaciones que estan a nombre del cliente
                //Precio_Total = 0
            }).ToList();
        }

        private List<RESERVAS_DE_HABITACIONES> SelectReservasActivas()
        {
            // obtengo una lista de las filas habidas en la tabla RESERVAS
            List<RESERVAS_DE_HABITACIONES> reservasList = _context.Reservas_De_Habitaciones.ToList();

            // retorno una lista de objetos RESERVA con la condicion de que el campo Reserva_Activa == 1
            return reservasList
                .Select(s => new RESERVAS_DE_HABITACIONES()
                {
                    ID_RESERVA_HABITACION = s.ID_RESERVA_HABITACION,
                    ID_HABITACION = s.ID_HABITACION,
                    ID_CLIENTE = s.ID_CLIENTE,
                    FECHA_INICIO = s.FECHA_INICIO,
                    FECHA_FIN = s.FECHA_FIN,
                    RESERVA_ACTIVA = s.RESERVA_ACTIVA
                })
                .Where(s => s.RESERVA_ACTIVA == 1)
                .ToList();
        }

        public void AddNewReserva(ReservasDeHabitacionesDTO reservaDTO)
        {
            RESERVAS_DE_HABITACIONES reserva = this.CreateRESERVAObjectByDTO(reservaDTO);
            _context.Reservas_De_Habitaciones.Add(reserva);

            _context.SaveChanges();
        }

        private RESERVAS_DE_HABITACIONES CreateRESERVAObjectByDTO(ReservasDeHabitacionesDTO reservaDTO)
        {
            RESERVAS_DE_HABITACIONES reserva = new()
            {
                ID_CLIENTE = reservaDTO.Id_Cliente,
                ID_HABITACION = reservaDTO.Id_Habitacion,
                FECHA_INICIO = reservaDTO.Fecha_Inicio,
                FECHA_FIN = reservaDTO.Fecha_Fin,
                RESERVA_ACTIVA = 1
            };

            return reserva;
        }

        public string DeleteReservaById(int id)
        {
            // obtengo el item que tenga el id obtenido por parametro
            RESERVAS_DE_HABITACIONES item = _context.Reservas_De_Habitaciones.Find(id);
            string returnValue;
            
            if(item == null)
            {
                returnValue = "ERROR: No se ha encontrado un registro con ese ID.";
            }
            else
            {
                _context.Reservas_De_Habitaciones.Remove(item);
                _context.SaveChanges();

                returnValue = "Reserva con id " + id + " eliminada.";
            }
            
            return returnValue;
        }

        public string UpdateReservaById(int id, ReservasDeHabitacionesDTO reservaDTO)
        {
            string mensaje = "";
            RESERVAS_DE_HABITACIONES item = _context.Reservas_De_Habitaciones.Find(id);

            if (item != null)
            {
                item.ID_CLIENTE = reservaDTO.Id_Cliente;
                item.ID_HABITACION = reservaDTO.Id_Habitacion;
                item.FECHA_INICIO = reservaDTO.Fecha_Inicio;
                item.FECHA_FIN = reservaDTO.Fecha_Fin;

                _context.SaveChanges(true);

                mensaje = "Registro con id " + id + " actualizado.";
            }
            else
            {
                mensaje = "ERROR: No existe un registro con id " + id + ".";
            }

            return mensaje;
        }

        public string DisableReservaById(int id)
        {
            string returnValue = "";
            RESERVAS_DE_HABITACIONES item = this._context.Reservas_De_Habitaciones.Find(id);
            if(item.RESERVA_ACTIVA == 0)
            {
                returnValue = "ERROR: La reserva ya estaba deshabilitada.";
            }
            else if (item.RESERVA_ACTIVA == 1)
            {
                item.RESERVA_ACTIVA = 0;
                returnValue = "Reserva deshabilitada.";
            }

            this._context.SaveChanges();


            return returnValue;
        }

        public string EnableReservaById(int id)
        {
            string returnValue = "";
            RESERVAS_DE_HABITACIONES item = this._context.Reservas_De_Habitaciones.Find(id);
            if (item.RESERVA_ACTIVA == 1)
            {
                returnValue = "ERROR: La reserva ya estaba habilitada.";
            }
            else if (item.RESERVA_ACTIVA == 0)
            {
                item.RESERVA_ACTIVA = 1;
                returnValue = "Reserva habilitada.";
            }

            this._context.SaveChanges();


            return returnValue;
        }


        public bool DoCheckIfReservaDeHabitacionWasAdded(ReservasDeHabitacionesDTO reserva)
        {
            RESERVAS_DE_HABITACIONES objReserva = _context.Reservas_De_Habitaciones
                .Where(x => x.ID_CLIENTE == reserva.Id_Cliente && x.ID_HABITACION == reserva.Id_Habitacion && x.FECHA_INICIO == reserva.Fecha_Inicio && x.FECHA_FIN == reserva.Fecha_Fin)
                .FirstOrDefault();

            if(objReserva != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public HABITACIONES GetHabitacionDataByIdTipoHabitacion(int idTipoHabitacion)
        {
            return _context.Habitaciones
                .Where(x => x.ID_HABITACION == idTipoHabitacion)
                .FirstOrDefault();
        }

        public bool ModificarCampoDisponible(HABITACIONES habitacion, int valorCampoDisponible)
        {
            habitacion.DISPONIBLE = 0;
            _context.SaveChanges();

            return false;
        }

        public ReservasDeHabitacionesDTO DoBuildReservasDeHabitacionesDTOByDatosCliente
        (
            CLIENTES datosCliente, 
            HABITACIONES datosHabitacion, 
            FechaInicioFinDTO objFechas
        )
        {
            return new ReservasDeHabitacionesDTO
            {
                Id_Cliente = datosCliente.ID_CLIENTE,
                Id_Habitacion = datosHabitacion.ID_HABITACION,
                Fecha_Inicio = objFechas.FechaInicio,
                Fecha_Fin = objFechas.FechaFin,
            };

        }




        // fin clase
    }
}
