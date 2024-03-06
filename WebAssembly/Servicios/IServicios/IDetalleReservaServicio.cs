using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface IDetalleReservaServicio
    {
        Task<ResponseDTO<List<DetalleReservaDTO>>> ObtenerDetallesReserva(int idReserva);

    }
}
