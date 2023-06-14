using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Habitaciones
{
    public class TiposDeHabitacionesService: ITiposDeHabitacionesService
    {
        private FCT10Context _context;
        public TiposDeHabitacionesService(FCT10Context context)
        {
            _context = context;
        }

        // Método que obtiene todas las filas de la tabla TIPOS_DE_HABITACIONES
        public List<TipoDeHabitacionDTO> GetTiposDeHabitaciones()
        {
            List<TIPOS_DE_HABITACIONES> tiposDeHabitacionesList = _context.Tipos_De_Habitaciones.ToList();

            List<TipoDeHabitacionDTO> returnValue = tiposDeHabitacionesList
                .Select(s => new TipoDeHabitacionDTO
                {
                    Categoria= s.categoria,
                    Descripcion = s.descripcion,
                    imgHabitacionBase64 = s.img_habitacion_base_64,
                    Tamaño = s.tamaño,
                    Precio = s.precio,
                    enlace_url = s.Enlace_Url
                })
                .ToList();

            return returnValue;
        }

        public List<DATOS_DE_HABITACIONES_DISPONIBLES> GetDatosDeHabitacionesDisponibles()
        {
            return this._context.Datos_De_Habitaciones_Disponibles.ToList();
        }

        public DATOS_DE_HABITACIONES_DISPONIBLES GetHabitacionById(int id)
        {
            var habitacion = _context.Datos_De_Habitaciones_Disponibles.FirstOrDefault(s => s.id_tipo_de_habitacion == id);
            
            if (habitacion != null) {
                return habitacion;
            }
            else
            {
                return new DATOS_DE_HABITACIONES_DISPONIBLES() { };
            }
        }







        // ---------------------------------------
        /*TODO: CORREGIR TODO ESTO
        public List<HabitacionesDto> Gethabitaciones(DateTime fechaInicio, DateTime fechaFin)
        {

            // obtengo una lista de las reservas activas
            List<RESERVAS> reservasList = this._context.Reservas.Where(x => x.RESERVA_ACTIVA == 1 && x.FECHA_INICIO >= DateTime.Now).ToList();

            List<int> idHabitacionesReservadas = reservasList
                .Where(x => (x.FECHA_INICIO <= fechaInicio && x.FECHA_FIN >= fechaInicio)
                        || (x.FECHA_INICIO <= fechaFin && x.FECHA_FIN >= fechaFin))
                .Select(s => s.ID_HABITACION).ToList();


            List<HABITACIONES> Habitaciones = this._context.Habitaciones.Where(x => !idHabitacionesReservadas.Contains(x.ID_HABITACION));

            // retorno esta lista de objetos RESERVA convertida a una lista de objetos ReservaDTO
            return Habitaciones.Select(s => new HabitacionesDto()
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
        */



        // fin clase
    }

    // fin namespace
}
