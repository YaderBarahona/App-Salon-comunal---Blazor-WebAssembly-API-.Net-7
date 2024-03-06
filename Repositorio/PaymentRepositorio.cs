using DTO;
using Modelo;
using Repositorio.IRepositorio;
using Stripe;
using Stripe.Checkout;

namespace Repositorio
{
    public class PaymentRepositorio : IPaymentRepositorio
    {
        public PaymentRepositorio()
        {
            StripeConfiguration.ApiKey = "sk_test_51OpJpJAvz1hx23WqAfHh0rWaI5j79lYXAa8vLGQV7A2YIkxxr6JcvAwjsDTs7wAFD5PjAMp3rz2QQVvAqsOhFOzo00FA0beoE2";    
        }                                           

        public string CreateCheckoutSession(List<ItemDTO> productos)
        {
            if (productos is null)
            {
                return null!;
            }

            var items = new List<SessionLineItemOptions>();

            productos.ForEach(prod => items.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    //precio de cada producto
                    UnitAmountDecimal = prod.Precio * 100,
                    Currency = "crc",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        //nombre de cada producto
                        Name = prod.Nombre,
                        //Descripcion de cada producto
                        Description = prod.IdProducto.ToString(),

                    }
                },
                Quantity = prod.Cantidad
            }));

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = items,
                Mode = "payment",
                SuccessUrl = "https://localhost:7290/pago-exito",
                CancelUrl = "https://localhost:7290/pago-error",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session.Url;

        }

        public string CreateCheckoutSession2(List<ItemDTO> productos)
        {
            if (productos is null)
            {
                return null!;
            }

            var items = new List<SessionLineItemOptions>();

            productos.ForEach(prod => items.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = prod.Precio * 100,
                    Currency = "crc",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = prod.Nombre,
                        Description = prod.IdProducto.ToString(),

                    }
                },
                Quantity = prod.Cantidad
            }));

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = items,
                Mode = "payment",
                SuccessUrl = "https://localhost:7290/pago-exito-completo",
                CancelUrl = "https://localhost:7290/pago-error",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session.Url;

        }
    }
}
