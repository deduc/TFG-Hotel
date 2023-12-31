﻿using TFGHotel.DTO;
using TFGHotel.Entities;

namespace TFGHotel.Services.ReservasDeServicios
{
    public interface IReservasDeServicios
    {
        List<RESERVAS_DE_SERVICIOS> GetReservasDeServicios();
        string AddNewReservasDeServicios(ReservasDeServicios_DTO reservasDeServiciosDTO);
        Task<string> DeleteReservasDeServiciosById(int id);
        List<DATOS_RESERVAS_DE_SERVICIOS_Y_CLIENTES> GetReservasDeServiciosByIdCliente(int idCliente);
        void CancelarReservaDeServicio(int idReservaServicio);
    }
}
