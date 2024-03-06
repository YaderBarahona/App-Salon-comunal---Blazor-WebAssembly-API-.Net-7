using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.IRepositorio;
using Servicio.IServicio;

namespace Servicio
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IGenericoRepositorio<Categoria> _modeloRepositorio;
        private readonly IMapper _mapper;

        public CategoriaServicio(IGenericoRepositorio<Categoria> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO categoria)
        {
            try
            {
                var categoriaDb = _mapper.Map<Categoria>(categoria);

                var response = await _modeloRepositorio.Crear(categoriaDb);

                if (response.IdCategoria != 0)
                    return _mapper.Map<CategoriaDTO>(response);
                else
                    throw new TaskCanceledException("No se puede crear..");
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CategoriaDTO categoria)
        {
            try
            {

                var query = _modeloRepositorio.Consultar(p => p.IdCategoria == categoria.IdCategoria);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {
                    result.Nombre = categoria.Nombre;

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

                var query = _modeloRepositorio.Consultar(p => p.IdCategoria == id);

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

        public async Task<List<CategoriaDTO>> Lista(string buscar)
        {
            try
            {
                //buscando el usuario por rol y nombre o correo
                var query = _modeloRepositorio.Consultar(p => p.Nombre!.ToLower().Contains(buscar.ToLower()));

                //convertir a lista de usuarioDTO
                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await query.ToListAsync());

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var query = _modeloRepositorio.Consultar(p => p.IdCategoria == id);
                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {
                    //retornamos convertido en UsuarioDTO
                    return _mapper.Map<CategoriaDTO>(result);
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
