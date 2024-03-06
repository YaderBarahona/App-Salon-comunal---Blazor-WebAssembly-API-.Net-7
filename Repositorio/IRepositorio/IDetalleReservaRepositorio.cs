using Modelo;

namespace Repositorio.IRepositorio
{
    public interface IDetalleReservaRepositorio : IGenericoRepositorio<DetalleReserva>
    {
        Task<List<DetalleReserva>> ObtenerDetallesPorReserva(int idReserva);

    }
}
