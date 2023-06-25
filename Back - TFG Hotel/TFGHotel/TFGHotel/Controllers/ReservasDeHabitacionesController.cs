using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFGHotel.DTO;
using TFGHotel.Entities;
using TFGHotel.Services.Clientes;
using TFGHotel.Services.Habitaciones;
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
    public class ReservasDeHabitacionesController : Controller
    {
        private readonly IReservasDeHabitacionesService _reservasDeHabitacionesService;
        private readonly IClientesService _clientesService;
        private readonly IUsuariosService _usuariosService;
        private readonly ITiposDeHabitacionesService _tiposDeHabitacionService;


        public ReservasDeHabitacionesController
            (
            IReservasDeHabitacionesService reservasService,
            IClientesService clientesService,
            IUsuariosService usuariosService,
            ITiposDeHabitacionesService tiposDeHabitacionService
            )
        {
            _reservasDeHabitacionesService = reservasService;
            _clientesService = clientesService;
            _usuariosService = usuariosService;
            _tiposDeHabitacionService = tiposDeHabitacionService;
        }


        [HttpGet]
        [Route("listar-reservas")]
        public List<ReservasDeHabitacionesDTO> GetReservas()
        {
            return _reservasDeHabitacionesService.GetReservas();
        }

        [HttpPost]
        [Route("crear-nueva-reserva")]
        public ActionResult<string> AddNewReserva(ReservasDeHabitacionesDTO reservaDTO)
        {
            _reservasDeHabitacionesService.AddNewReserva(reservaDTO);
            return Ok("Reserva añadida");
        }

        [HttpDelete]
        [Route("borrar-reserva/{id:int}")]
        public ActionResult<string> DeleteReservaById(int id)
        {
            var mensaje = _reservasDeHabitacionesService.DeleteReservaById(id);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("actualizar-reserva/{id:int}")]
        public ActionResult<string> UpdateReservaById(int id, ReservasDeHabitacionesDTO reservaDTO)
        {
            var mensaje = _reservasDeHabitacionesService.UpdateReservaById(id, reservaDTO);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("deshabilitar-reserva/{id:int}")]
        public ActionResult<string> DisableReservaById(int id)
        {
            var mensaje = _reservasDeHabitacionesService.DisableReservaById(id);

            return Ok(mensaje);
        }

        [HttpPut]
        [Route("habilitar-reserva/{id:int}")]
        public ActionResult<string> EnableReservaById(int id)
        {
            var mensaje = _reservasDeHabitacionesService.EnableReservaById(id);

            return Ok(mensaje);
        }

        [HttpPost]
        [Route("reservar-habitacion-completa")]
        public string DoReservarHabitacion(objUsernameIdTipoHabitacionFechasDTO objUsernameTipoHabitacionFechasDTO)
        {
            // Obtengo los valores del objeto recibido por parametros
            string username = objUsernameTipoHabitacionFechasDTO.Username;
            int idTipoHabitacion = objUsernameTipoHabitacionFechasDTO.idTipoHabitacion;
            bool semaforo;
            bool usuarioExiste;
            bool tipoHabitacionExiste;
            FechaInicioFinDTO objFechas = new FechaInicioFinDTO
            {
                FechaInicio = objUsernameTipoHabitacionFechasDTO.FechaInicio,
                FechaFin = objUsernameTipoHabitacionFechasDTO.FechaFin
            };


            usuarioExiste = this.DoCheckIfUserExists(username);
            tipoHabitacionExiste = this.DoCheckIfIdTipoHabitacionExists(idTipoHabitacion);

            if (!usuarioExiste) return "ERROR: Usuario no existe";
            if (!tipoHabitacionExiste) return "ERROR: ID de tipo de habitación no existe";

            // Obtengo los datos del usuario
            USUARIOS datosUsuario = _usuariosService.GetUserDataByUsername(username);

            // Si el usuario existe, creo un objeto CLIENTES y lo añado a la tabla CLIENTES
            if (datosUsuario != null)
            {
                /* 
                 * Si el cliente no existe, lo añado a la tabla clientes
                 * En caso contrario no lo añado.
                 */
                if (_clientesService.DoCheckIfClienteExists(username) == false)
                {
                    CLIENTES cliente = this.CreateObjectCLIENTESByUSUARIOSObject(datosUsuario);

                    string errorsString = _clientesService.AddNewCliente(cliente);

                    if (errorsString.Length > 0) return errorsString;
                }
            }
            else
            {
                return "ERROR: No se ha podido obtener los datos del usuario por un error desconocido. Puede que sea la base de datos.";
            }

            // Obtengo los datos del cliente asociados al username
            CLIENTES datosCliente = this._clientesService.GetDatosClienteByUsername(username);

            // Obtengo los datos de la habitacion que coincida con idTipoHabitacion
            HABITACIONES datosHabitacion = this._reservasDeHabitacionesService.GetHabitacionDataByIdTipoHabitacion(idTipoHabitacion);
            if(datosHabitacion.DISPONIBLE == 0) return "ERROR 500: La base de datos ha obtenido una de forma errónea.";

            // Modifico el campo DISPONIBLE=0 de la habitacion obtenida
            this._reservasDeHabitacionesService.ModificarCampoDisponible(datosHabitacion, idTipoHabitacion);

            // Construyo el objeto RESERVAS_DE_HABITACIONES con los datos obtenidos hasta ahora
            ReservasDeHabitacionesDTO reservaObjDTO = this._reservasDeHabitacionesService.DoBuildReservasDeHabitacionesDTOByDatosCliente(
                datosCliente, datosHabitacion, objFechas);

            // Invoco un método de la propia clase (un endpoint) para añadir una reserva
            this.AddNewReserva(reservaObjDTO);

            // Compruebo si la reserva ha sido añadida correctamente
            semaforo = this._reservasDeHabitacionesService.DoCheckIfReservaDeHabitacionWasAdded(reservaObjDTO);

            if (semaforo)
            {
                return "Reserva de habitación insertada con éxito.";
            }


            return "ERROR: Algún error desconocido habrá por ahí.";

            // fin metodo
        }

        private bool DoCheckIfUserExists(string username)
        {
            return _usuariosService.DoCheckIfUserExists(username);
        }
        private bool DoCheckIfIdTipoHabitacionExists(int idTipoHabitacion)
        {
            return _tiposDeHabitacionService.DoCheckIfIdTipoHabitacionExists(idTipoHabitacion);
        }
        private CLIENTES CreateObjectCLIENTESByUSUARIOSObject(USUARIOS datosUsuario)
        {
            return this._clientesService.CreateObjectCLIENTESByUSUARIOSObject(datosUsuario);
        }

       [HttpGet]
       [Route("get-reservas-de-habitaciones-by-id-cliente")]
        public List<DATOS_HABITACIONES_TIPOS_FECHAS> GetReservasDeHabitacionesByIdCliente(int idCliente)
        {
            var misReservas = this._reservasDeHabitacionesService.GetReservasDeHabitacionesByIdCliente(idCliente);

            return misReservas;
        }


        // fin clase

        [HttpGet]
        [Route("cancelar-reserva-de-habitacion")]
        public void CancelarReservaDeHabitacion(int idHabitacion)
        {
            this._reservasDeHabitacionesService.CancelarReservaDeHabitacion(idHabitacion);
        }
    }
}
