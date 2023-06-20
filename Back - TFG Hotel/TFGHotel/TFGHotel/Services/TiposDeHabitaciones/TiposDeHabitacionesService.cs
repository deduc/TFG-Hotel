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

            var datos = _context.Datos_De_Habitaciones_Disponibles.FirstOrDefault(s => s.ID_TIPO_DE_HABITACION == id);
            
            if (datos != null) 
            {
                return new DatosHabitacionDisponibleDTO()
                {
                    idtipodehabitacion = datos.ID_TIPO_DE_HABITACION,
                    habitacionesdisponibles = datos.HABITACIONES_DISPONIBLES,
                    categoria= datos.CATEGORIA ,
                    precio = datos.PRECIO ,
                    descripcion = datos.DESCRIPCION ,
                    imghabitacionbase64 = datos.IMG_HABITACION_BASE_64 ,
                    tamano = datos.TAMAÑO
                };
            }
            else
            {
                return new DatosHabitacionDisponibleDTO() { };
            }
            // fin metodo
        }

        // fin clase
    }

    // fin namespace
}
