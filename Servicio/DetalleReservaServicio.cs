using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.IRepositorio;
using Servicio.IServicio;
using System.Linq.Expressions;

namespace Servicio
{
    public class DetalleReservaServicio : IDetalleReservaServicio
    {
        private readonly IDetalleReservaRepositorio _detalleReservaRepositorio;
        private readonly IMapper _mapper;

        public DetalleReservaServicio(IMapper mapper, IDetalleReservaRepositorio detalleReservaRepositorio)
        {
            _mapper = mapper;
            _detalleReservaRepositorio = detalleReservaRepositorio;
        }

        public async Task<List<DetalleReservaDTO>> ObtenerDetallesReserva(int idReserva)
        {
            try
            {
                var query = _detalleReservaRepositorio.Consultar(p => p.IdReserva == idReserva);

                List<DetalleReservaDTO> lista = _mapper.Map<List<DetalleReservaDTO>>(await query.ToListAsync());

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener detalles de reserva: " + ex.Message);
            }
        }


    }
}
