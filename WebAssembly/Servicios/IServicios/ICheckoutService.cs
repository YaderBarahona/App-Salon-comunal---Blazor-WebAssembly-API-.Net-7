using DTO;

namespace WebAssembly.Servicios.IServicios
{
    public interface ICheckoutService
    {
        Task<string> Checkout(List<ItemDTO> items);

        Task<string> Checkout2(List<ItemDTO> items);
    }
}
