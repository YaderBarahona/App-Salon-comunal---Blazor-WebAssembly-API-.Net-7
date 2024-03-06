using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface IProductoServicio
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar);

        Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);

        Task<ResponseDTO<ProductoDTO>> Obtener(int id);

        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO producto);

        Task<ResponseDTO<bool>> Editar(ProductoDTO producto);

        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
