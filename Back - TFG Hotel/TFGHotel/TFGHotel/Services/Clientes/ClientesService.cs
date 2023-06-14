using TFGHotel.Context;
using TFGHotel.DTO;

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
    }
}
