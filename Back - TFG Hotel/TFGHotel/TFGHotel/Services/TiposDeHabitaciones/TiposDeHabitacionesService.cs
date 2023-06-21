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
                    categoria= s.CATEGORIA,
                    descripcion = s.DESCRIPCION,
                    img_habitacion_base_64 = s.IMG_HABITACION_BASE_64,
                    tamaño = s.TAMAÑO,
                    precio = s.PRECIO,
                    enlace_url = s.ENLACE_URL
                })
                .ToList();

            return returnValue;
        }

        public List<DATOS_DE_HABITACIONES_DISPONIBLES> GetDatosDeHabitacionesDisponibles()
        {
            return this._context.Datos_De_Habitaciones_Disponibles.ToList();
        }

        public DatosHabitacionDisponibleDTO GetHabitacionById(int id)
        {

            List<DATOS_DE_HABITACIONES_DISPONIBLES> datos = _context.Datos_De_Habitaciones_Disponibles
                .Where(s => s.ID_TIPO_DE_HABITACION == id)
                .ToList();
            
            if (datos.Count == 1) 
            {
                return new DatosHabitacionDisponibleDTO()
                {
                    idtipodehabitacion = datos[0].ID_TIPO_DE_HABITACION,
                    habitacionesdisponibles = datos[0].HABITACIONES_DISPONIBLES,
                    categoria= datos[0].CATEGORIA ,
                    precio = datos[0].PRECIO ,
                    descripcion = datos[0].DESCRIPCION ,
                    imghabitacionbase64 = datos[0].IMG_HABITACION_BASE_64 ,
                    tamano = datos[0].TAMAÑO
                };
            }
            else
            {
                return new DatosHabitacionDisponibleDTO() { };
            }
            // fin metodo
        }

        public bool DoCheckIfIdTipoHabitacionExists(int idTipoHabitacion)
        {
            bool semaforo;

            TIPOS_DE_HABITACIONES tipoHabitacion = _context.Tipos_De_Habitaciones
                .Where(x => x.ID_TIPO_DE_HABITACION == idTipoHabitacion)
                .FirstOrDefault();

            if (tipoHabitacion != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // fin clase
    }

    // fin namespace
}
