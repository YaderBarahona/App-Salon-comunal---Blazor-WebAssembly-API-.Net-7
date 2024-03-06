using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.IRepositorio;
using Servicio.IServicio;

namespace Servicio
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IGenericoRepositorio<Producto> _modeloRepositorio;
        private readonly IMapper _mapper;

        public ProductoServicio(IGenericoRepositorio<Producto> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var query = _modeloRepositorio.Consultar(
                    p => p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                         p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower()),
                    p => p.Cantidad > 0); // Filtro para la cantidad del producto

                // Convertir a lista de ProductoDTOs
                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await query.ToListAsync());

                return lista;
            }
            catch
            {
                throw;
            }
        }


        public async Task<ProductoDTO> Crear(ProductoDTO producto)
        {
            try
            {
                var categoriaDb = _mapper.Map<Producto>(producto);

                var response = await _modeloRepositorio.Crear(categoriaDb);

                if (response.IdCategoria != 0)
                    return _mapper.Map<ProductoDTO>(response);
                else
                    throw new TaskCanceledException("No se puede crear..");
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductoDTO producto)
        {
            try
            {

                var query = _modeloRepositorio.Consultar(p => p.IdProducto == producto.IdProducto);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {
                    result.Nombre = producto.Nombre;
                    result.Descripcion = producto.Descripcion;
                    result.IdCategoria = producto.IdCategoria;
                    result.Precio = producto.Precio;
                    result.Cantidad = producto.Cantidad;
                    result.Imagen = producto.Imagen;

                    //respuesta generada del metodo del repositorio
                    var response = await _modeloRepositorio.Editar(result);

                    if (!response)
                        throw new TaskCanceledException("No se pudo editar..");

                    return response;

                }
                else
                    throw new TaskCanceledException("No se pudo editar..");
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {

                var query = _modeloRepositorio.Consultar(p => p.IdProducto == id);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {

                    var response = await _modeloRepositorio.Eliminar(result);

                    if (!response)
                    {
                        throw new TaskCanceledException("No se pudo eliminar..");
                    }

                    return response;

                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try
            {
                //buscando el usuario por rol y nombre o correo
                var query = _modeloRepositorio.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower()));

                //innerjoin con categoria mediante el la fk 
                query = query.Include(c => c.IdCategoriaNavigation);

                //convertir a lista de usuarioDTO
                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await query.ToListAsync());

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            try
            {
                var query = _modeloRepositorio.Consultar(p => p.IdProducto == id);

                //agregando categoria
                query = query.Include(c => c.IdCategoriaNavigation);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {
                    return _mapper.Map<ProductoDTO>(result);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias..");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
