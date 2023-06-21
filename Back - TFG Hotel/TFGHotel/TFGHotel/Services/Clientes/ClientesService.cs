using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Clientes
{
    public class ClientesService: IClientesService
    {
        public FCT10Context _context { get; set; }
        
        // constructor
        public ClientesService(FCT10Context context)
        {
            _context = context;
        }

        public List<ClientesDTO> GetClientes()
        {
            var clientes = _context.Clientes.ToList();
            return clientes.Select(s => new ClientesDTO()
            {
                Nombre = s.NOMBRE,
                Apellidos = s.APELLIDOS,
            }).ToList();
        }

        public CLIENTES GetClienteByUsername(string username)
        {
            return _context.Clientes
                .Where(x => x.USERNAME == username)
                .FirstOrDefault();

        }

        public string AddNewCliente(CLIENTES objCliente)
        {
            string returnValue = "";
            bool semaforo;

            _context.Clientes.Add(objCliente);
            _context.SaveChanges();
            
            // Comprobar si el cliente ha sido añadido con éxito en la tabla
            semaforo = this.DoCheckIfClienteExists(objCliente.USERNAME);
            if (semaforo == false)
            {
                returnValue = "ERROR: Error desconocido, no se ha podido añadir el cliente.";
                
                return returnValue;
            }


            return returnValue;
        }

        public bool DoCheckIfClienteExists(string username)
        {
            var cliente = _context.Clientes
                .Where(x => x.USERNAME == username)
                .FirstOrDefault();

            if(cliente != null)
            {
                return true;
            }

            return false;
        }

        public CLIENTES GetDatosClienteByUsername(string username)
        {
            return _context.Clientes
                .Where(x => x.USERNAME == username)
                .First();
        }

        public CLIENTES CreateObjectCLIENTESByUSUARIOSObject(USUARIOS datosUsuario)
        {
            return new CLIENTES()
            {
                ID_CLIENTE = 0,
                USERNAME = datosUsuario.USERNAME,
                EMAIL = datosUsuario.EMAIL,
                DNI = datosUsuario.DNI,
                NOMBRE = datosUsuario.NOMBRE,
                APELLIDOS = datosUsuario.APELLIDOS,
            };
        }



        // fin clase
    }
}
