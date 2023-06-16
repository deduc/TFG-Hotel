using TFGHotel.Entities;

namespace TFGHotel.ClasesAuxiliares
{
    public class CantidadYDatosHabitacion
    {
        public int CantidadDeHabitaciones;
        // Atributo nullable
        public TIPOS_DE_HABITACIONES? DatosHabitacion;

        
        public CantidadYDatosHabitacion
        (
            int CantidadDeHabitaciones,
            TIPOS_DE_HABITACIONES DatosHabitacion
        ) 
        {
            this.CantidadDeHabitaciones = CantidadDeHabitaciones;
            this.DatosHabitacion = DatosHabitacion;
        }

        // fin clase
    }
}
