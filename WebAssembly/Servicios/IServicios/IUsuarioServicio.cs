using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface IUsuarioServicio
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);

        Task<ResponseDTO<UsuarioDTO>> Obtener(int id);

        Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO model);

        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO usuario);

        Task<ResponseDTO<bool>> Editar(UsuarioDTO usuario);

        Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
