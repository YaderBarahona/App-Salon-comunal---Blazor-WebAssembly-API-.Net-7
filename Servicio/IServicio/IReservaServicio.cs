using DTO;

namespace Servicio.IServicio
{
    public interface IReservaServicio
    {
        Task<ReservaDTO> RegistrarReserva(ReservaDTO reserva);

        Task<List<ReservaDTO>> ReservasUsuario(int idUsuario);

        Task<bool> ActualizarPago(int idUsuario);

        Task<List<ReservaDTO>> Lista();

    }
}
