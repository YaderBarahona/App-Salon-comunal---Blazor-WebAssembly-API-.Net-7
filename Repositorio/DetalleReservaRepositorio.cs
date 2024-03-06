using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.DBContext;
using Repositorio.IRepositorio;

namespace Repositorio
{
    public class DetalleReservaRepositorio : GenericoRepositorio<DetalleReserva>, IDetalleReservaRepositorio
    {
        private readonly DbecommerceSalonComunalContext _dbContext;

        public DetalleReservaRepositorio(DbecommerceSalonComunalContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DetalleReserva>> ObtenerDetallesPorReserva(int idReserva)
        {
            try
            {
                // Consulta los detalles de reserva asociados al ID de reserva proporcionado,
                // incluyendo los datos del producto asociado a cada detalle de reserva
                var detallesReserva = await _dbContext.DetalleReserva
                    .Include(dr => dr.IdProductoNavigation) // Incluye los datos del producto asociado al detalle de reserva
                    .Where(dr => dr.IdReserva == idReserva)
                    .ToListAsync();

                return detallesReserva;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al obtener detalles de reserva: " + ex.Message);
            }
        }
    }
}
