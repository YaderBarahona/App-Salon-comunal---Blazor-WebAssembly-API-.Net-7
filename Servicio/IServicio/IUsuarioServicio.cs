using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.IServicio
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioDTO>> Lista(string rol, string buscar);
        Task<UsuarioDTO> Obtener(int id);
        Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<UsuarioDTO> Crear(UsuarioDTO usuario);
        Task<bool> Editar(UsuarioDTO usuario);
        Task<bool> Eliminar(int id);
    }
}
