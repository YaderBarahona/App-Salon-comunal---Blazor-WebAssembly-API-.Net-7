using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar);

        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);

        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO categoria);

        Task<ResponseDTO<bool>> Editar(CategoriaDTO categoria);

        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
