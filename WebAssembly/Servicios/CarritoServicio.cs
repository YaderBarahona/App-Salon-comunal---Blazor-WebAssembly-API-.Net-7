using Blazored.LocalStorage;
using Blazored.Toast.Services;
using DTO;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class CarritoServicio : ICarritoServicio
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;


        public CarritoServicio(ILocalStorageService localStorageService, 
            ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;

        }

        public event Action MostrarItems;

        public async Task AgregarProductos(CarritoDTO carrito)
        {
            try
            {
                //obtener lista de carrito 
                var carritoList = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

                //carrito no existe
                if (carritoList == null)
                {
                    //creamos el carrito
                    carritoList = new List<CarritoDTO>();
                }

                var encontrado = carritoList.FirstOrDefault(c => c.Producto.IdProducto == carrito.Producto.IdProducto);

                //se encontro el producto en el carrito
                if (encontrado != null)
                {
                    //removiendo del carrito para evitar duplicidad de producto
                    carritoList.Remove(encontrado);
                }

                //agregando el producto al carrito
                carritoList.Add(carrito);

                //guardamos en el localstorage el carrito
                await _localStorageService.SetItemAsync("carrito", carritoList);

                if (encontrado != null)
                {
                    _toastService.ShowSuccess("Producto actualizado en carrito");
                }
                else
                {
                    _toastService.ShowSuccess("Producto agregado al carrito");
                }

                //actualizando vista
                MostrarItems.Invoke();

            }
            catch (Exception)
            {
                _toastService.ShowError("No se puedo agregar al carrito");
                //throw;
            }
        }

        public int CantidadProducto()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");

            return carrito == null ? 0 : carrito.Count;
        }


        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

            if (carrito == null)
            {
                carrito = new List<CarritoDTO>();
            }

            return carrito;
        }

        public async Task EliminarCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

                if (carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);

                    if (elemento != null)
                    {
                        carrito.Remove(elemento);

                        await _localStorageService.SetItemAsync("carrito", carrito);

                        MostrarItems.Invoke();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");

            MostrarItems.Invoke();
        }




    }
}
