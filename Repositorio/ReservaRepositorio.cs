using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.DBContext;
using Repositorio.IRepositorio;

namespace Repositorio
{
    public class ReservaRepositorio : GenericoRepositorio<Reserva>, IReservaRepositorio
    {
        private readonly DbecommerceSalonComunalContext _dbContext;

        public ReservaRepositorio(DbecommerceSalonComunalContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reserva> Registrar(Reserva modelo)
        {
            Reserva reserva = new Reserva();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleReserva dr in modelo.DetalleReservas)
                    {
                        Producto producto = _dbContext.Producto.Where(p => p.IdProducto == dr.IdProducto).First();

                        producto.Cantidad = producto.Cantidad - dr.Cantidad;
                        _dbContext.Producto.Update(producto);
                    }

                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Reserva.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    reserva = modelo;

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return reserva;
        }

    }
}
