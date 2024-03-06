using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.IServicio
{
    public interface IProductoServicio
    {
        Task<List<ProductoDTO>> Lista(string buscar);

        //lista de productos del front 
        Task<List<ProductoDTO>> Catalogo(string categoria, string buscar);
        Task<ProductoDTO> Obtener(int id);
        Task<ProductoDTO> Crear(ProductoDTO producto);
        Task<bool> Editar(ProductoDTO producto);
        Task<bool> Eliminar(int id);
    }
}
