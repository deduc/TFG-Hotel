using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.Clientes
{
    public interface IClientesService
    {
        List<ClientesDTO> GetClientes();
        int GetIdClienteByUsername(string Username);
        string AddNewCliente(CLIENTES objCliente);
        bool AddNewClienteByUserData(USUARIOS datosUsuario);
        bool DoCheckIfClienteExists(string username);
        CLIENTES GetDatosClienteByUsername(string username);
        CLIENTES CreateObjectCLIENTESByUSUARIOSObject(USUARIOS datosUsuario);
    }
}
