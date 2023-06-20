using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Clientes
{
    public interface IClientesService
    {
        List<ClientesDTO> GetClientes();
        string AddNewCliente(CLIENTES objCliente);
        bool DoCheckIfClienteExists(string username);
        CLIENTES GetDatosClienteByUsername(string username);
    }
}
