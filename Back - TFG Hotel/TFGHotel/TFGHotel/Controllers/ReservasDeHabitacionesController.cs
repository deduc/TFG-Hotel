using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.Clientes;
using TFGHotel.Services.Reservas;
using TFGHotel.Services.Usuarios;

namespace TFGHotel.Controllers
{
    /*
     * Decoradores de clase para indicar 
     *  que es un controlador para una api 
     *  y que la ruta raíz es /api/reservas
     */
    [ApiController]
    [Route("api/reservas-de-habitaciones")]
    public class ReservasDeHabitacionesController: Controller
    {
        private readonly IReservasDeHabitacionesService _reservasService;
        private readonly IClientesService _clientesService;
        private readonly IUsuariosService _usuariosService;


        public ReservasDeHabitacionesController
            (
            IReservasDeHabitacionesService reservasService,
            IClientesService clientesService,
            IUsuariosService usuariosService
            )
        {
            _reservasService = reservasService;
            _clientesService = clientesService;
            _usuariosService = usuariosService;

        }

        [HttpGet]
        [Route("listar-reservas")]
        public List<ReservasDeHabitacionesDTO> GetReservas()
        {
            return _reservasService.GetReservas();
        }

        [HttpPost]
        [Route("crear-nueva-reserva")]
        public ActionResult<string> AddNewReserva(ReservasDeHabitacionesDTO reservaDTO)
        {
            _reservasService.AddNewReserva(reservaDTO);
            return Ok("Reserva añadida");
        }

        [HttpDelete]
        [Route("borrar-reserva/{id:int}")]
        public ActionResult<string> DeleteReservaById(int id)
        {
            var mensaje = _reservasService.DeleteReservaById(id);
            
            return Ok(mensaje);
        }

        [HttpPut]
        [Route("actualizar-reserva/{id:int}")]
        public ActionResult<string> UpdateReservaById(int id, ReservasDeHabitacionesDTO reservaDTO)
        {
            var mensaje = _reservasService.UpdateReservaById(id, reservaDTO);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("deshabilitar-reserva/{id:int}")]
        public ActionResult<string> DisableReservaById(int id)
        {
            var mensaje = _reservasService.DisableReservaById(id);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("habilitar-reserva/{id:int}")]
        public ActionResult<string> EnableReservaById(int id)
        {
            var mensaje = _reservasService.EnableReservaById(id);

            return Ok(mensaje);
        }

        [HttpPost]
        [Route("reservar-habitacion-completa")]
        public string DoReservarHabitacion(objUsernameIdTipoHabitacionFechasDTO objUsernameTipoHabitacionFechasDTO)
        {
            // Obtengo los valores del objeto recibido por parametros
            string username = objUsernameTipoHabitacionFechasDTO.Username;
            int idTipoHabitacion = objUsernameTipoHabitacionFechasDTO.idTipoHabitacion;
            FechaInicioFinDTO objFechas = new FechaInicioFinDTO
            {
                FechaInicio = objUsernameTipoHabitacionFechasDTO.FechaInicio,
                FechaFin = objUsernameTipoHabitacionFechasDTO.FechaFin
            };


            // Obtengo los datos del usuario
            USUARIOS datosUsuario = _usuariosService.GetUserDataByUsername(username);
            
            // Si el usuario existe, creo un objeto CLIENTES y lo añado a la tabla CLIENTES
            if (datosUsuario != null)
            {
                CLIENTES cliente = new CLIENTES()
                {
                    ID_CLIENTE = 0,
                    USERNAME = datosUsuario.USERNAME,
                    EMAIL = datosUsuario.EMAIL,
                    DNI = datosUsuario.DNI,
                    NOMBRE = datosUsuario.NOMBRE,
                    APELLIDOS = datosUsuario.APELLIDOS,
                };

                string errorsString = _clientesService.AddNewCliente(cliente);
                if (errorsString.Length > 0) return errorsString;
            }
            else
            {
                return "ERROR: DatosUsuario es null";
            }

            // Obtengo los datos del cliente asociados al username
            CLIENTES datosCliente = this._clientesService.GetDatosClienteByUsername(username);

            // Obtengo los datos de la habitacion que coincida con idTipoHabitacion
            HABITACIONES     datosHabitacion = this._reservasService.GetHabitacionDataByIdTipoHabitacion(idTipoHabitacion);
            // Modifico el campo DISPONIBLE=0 de la habitacion obtenida
            this._reservasService.ModificarCampoDisponible(datosHabitacion, idTipoHabitacion);

            // Construyo el objeto RESERVAS_DE_HABITACIONES con los datos obtenidos hasta ahora
            ReservasDeHabitacionesDTO reserva = this._reservasService.DoBuildReservasDeHabitacionesDTOByDatosCliente(
                datosCliente, datosHabitacion, objFechas);

            // Invoco el método para añadir una reserva
            this.AddNewReserva(reserva);

            // Compruebo si la reserva ha sido añadida correctamente
            bool semaforo = this._reservasService.DoCheckIfReservaDeHabitacionWasAdded(reserva);

            if (semaforo)
            {
                return "Reserva de habitación insertada con éxito sheeeeeeesh.";
            }
            
            
            return "ERROR: Algún error desconocido habrá por ahí.";

            // fin metodo
        }

        // TODO     hacer cuando se pueda reservar habitaciones
        //[HttpPost]
        //[Route("get-reservas-de-habitaciones-by-username")]
        //public List<> GetReservasDeHabitacionesByUsername(string username) 
        //{

        //}


        // fin clase
    }
}
