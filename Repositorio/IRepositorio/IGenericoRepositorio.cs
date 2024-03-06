using System.Linq.Expressions;

namespace Repositorio.IRepositorio
{
    //interfaz generica que contendrá los metodos usuales de CRUD que utilicen todas los modelos en comun
    //T representando una clase de los modelos 
    public interface IGenericoRepositorio<T> where T : class
    {
        //metodo para retornar el modelo
        IQueryable<T> Consultar(Expression<Func<T, bool>>? filtro = null, Expression<Func<T, bool>>? filtroCantidad = null);

        //metodo asincrono para retornar un modelo
        Task<T> Crear(T modelo);

        Task<bool> Editar(T modelo);

        Task<bool> Eliminar(T modelo);

    }
}
