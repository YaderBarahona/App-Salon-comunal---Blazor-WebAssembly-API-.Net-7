using DTO;
using Modelo;
using Stripe.Checkout;

namespace Repositorio.IRepositorio
{
    public interface IPaymentRepositorio
    {
        string CreateCheckoutSession(List<ItemDTO> productos);

        string CreateCheckoutSession2(List<ItemDTO> productos);
    }
}
