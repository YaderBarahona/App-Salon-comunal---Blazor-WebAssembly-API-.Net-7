using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.IServicio
{
    public interface ICategoriaServicio
    {
        Task<List<CategoriaDTO>> Lista(string buscar);
        Task<CategoriaDTO> Obtener(int id);
        Task<CategoriaDTO> Crear(CategoriaDTO categoria);
        Task<bool> Editar(CategoriaDTO categoria);
        Task<bool> Eliminar(int id);
    }
}
