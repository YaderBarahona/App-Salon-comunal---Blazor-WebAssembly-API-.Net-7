using Microsoft.EntityFrameworkCore;
using Repositorio.DBContext;
using Repositorio.IRepositorio;
using System.Linq.Expressions;


namespace Repositorio
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : class
    {
        private readonly DbecommerceSalonComunalContext _dbContext;

        public GenericoRepositorio(DbecommerceSalonComunalContext dbContext)
        {
            _dbContext = dbContext;
        }

        //implementando el metodo de la interfaz
        //GET ALL - SELECT
        //public IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null, Expression<Func<T, bool>>? filtroCantidad = null)
        //{
        //    IQueryable<T> query = (filtro == null) ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filtro);
        //    return query;

        //}

        public IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null, Expression<Func<T, bool>>? filtroCantidad = null)
        {
            IQueryable<T> query = (filtro == null) ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filtro);

            if (filtroCantidad != null)
            {
                query = query.Where(filtroCantidad);
            }

            return query;
        }


        //POST - INSERT 
        public async Task<T> Crear(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }
    }
}
