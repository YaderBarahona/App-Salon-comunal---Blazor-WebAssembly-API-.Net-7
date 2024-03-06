using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface IReservaServicio
    {
        Task<ResponseDTO<ReservaDTO>> Registrar(ReservaDTO reserva);
        Task<ResponseDTO<List<ReservaDTO>>> ReservasUsuario(int idUsuario);
        Task<ResponseDTO<bool>> ActualizarPago(int idUsuario);

        Task AgregarID(int id);

        Task<int?> ObtenerID();

        Task<ResponseDTO<List<ReservaDTO>>> Lista();

    }
}
