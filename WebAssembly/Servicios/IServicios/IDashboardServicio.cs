using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();

    }
}
