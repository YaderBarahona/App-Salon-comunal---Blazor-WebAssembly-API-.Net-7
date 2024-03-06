using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.IRepositorio;
using Servicio.IServicio;

namespace Servicio
{
    public class ReservaServicio : IReservaServicio
    {
        private readonly IReservaRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;

        public ReservaServicio(IReservaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<ReservaDTO> RegistrarReserva(ReservaDTO reserva)
        {
            try
            {
                var reservaDB = _mapper.Map<Reserva>(reserva);

                var responseReserva = await _modeloRepositorio.Registrar(reservaDB);

                if (responseReserva.IdReserva != 0)
                    return _mapper.Map<ReservaDTO>(responseReserva);
                else
                    throw new TaskCanceledException("No se puede crear..");
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ReservaDTO>> ReservasUsuario(int idUsuario)
        {
            try
            {
                // Realiza la consulta utilizando el método Consultar del repositorio genérico
                var query = _modeloRepositorio.Consultar(f => f.IdUsuario == idUsuario);

                // Convierte el resultado en una lista y retórnalo
                List<ReservaDTO> reservas = _mapper.Map<List<ReservaDTO>>(await query.ToListAsync());
                return reservas;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ActualizarPago(int idReserva)
        {
            try
            {
                var query = _modeloRepositorio.Consultar(p => p.IdReserva == idReserva);

                var result = await query.FirstOrDefaultAsync();

                if (result != null)
                {


                    result.TotalPagado = (result.TotalPrecio - result.TotalPagado) + result.TotalPagado;
                    result.EstadoReserva = true;

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

        public async Task<List<ReservaDTO>> Lista()
        {
            try
            {
                //buscando el usuario por rol y nombre o correo
                var query = _modeloRepositorio.Consultar();

                //convertir a lista de usuarioDTO
                List<ReservaDTO> lista = _mapper.Map<List<ReservaDTO>>(await query.ToListAsync());

                return lista;
            }
            catch
            {
                throw;
            }
        }

    }
}
