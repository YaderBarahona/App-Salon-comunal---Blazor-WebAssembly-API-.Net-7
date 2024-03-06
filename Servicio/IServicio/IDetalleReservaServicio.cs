using DTO;

namespace Servicio.IServicio
{
    public interface IDetalleReservaServicio
    {
        Task<List<DetalleReservaDTO>> ObtenerDetallesReserva(int idReserva);

    }
}
