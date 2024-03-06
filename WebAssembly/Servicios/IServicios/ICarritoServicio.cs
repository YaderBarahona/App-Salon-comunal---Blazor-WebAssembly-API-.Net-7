using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface ICarritoServicio
    {
        //accion de contador de items del carrito
        event Action MostrarItems;

        int CantidadProducto();

        Task AgregarProductos(CarritoDTO carrito);

        Task EliminarCarrito(int idProducto);

        Task<List<CarritoDTO>> DevolverCarrito();

        Task LimpiarCarrito();

    }
}
