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

        // fin clase
    }

    // fin namespace
}
