using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.IRepositorio;
using Servicio.IServicio;

namespace Servicio
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IMapper _mapper;

        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        //metodo para el logeo
        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var query = _modeloRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                    return _mapper.Map<SesionDTO>(result);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch
            {
                throw;
            }
        }
        public async Task<UsuarioDTO> Crear(UsuarioDTO usuario)
        {
            try
            {
                var usuarioDb = _mapper.Map<Usuario>(usuario);

                var response = await _modeloRepositorio.Crear(usuarioDb);

                if (response.IdUsuario != 0)
                    return _mapper.Map<UsuarioDTO>(response);
                else
                    throw new TaskCanceledException("No se puede crear..");
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(UsuarioDTO usuario)
        {
            try
            {

                var query = _modeloRepositorio.Consultar(p => p.IdUsuario == usuario.IdUsuario);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {
                    result.Nombre = usuario.Nombre;
                    result.Correo = usuario.Correo;
                    result.Clave = usuario.Clave;

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

                var query = _modeloRepositorio.Consultar(p => p.IdUsuario == id);

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

        public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {
                //buscando el usuario por rol y nombre o correo
                var query = _modeloRepositorio.Consultar(p => p.Rol == rol && string.Concat(p.Nombre.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));

                //convertir a lista de usuarioDTO
                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await query.ToListAsync());

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Obtener(int id)
        {
            try
            {
                var query = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {
                    //retornamos convertido en UsuarioDTO
                    return _mapper.Map<UsuarioDTO>(result);
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
