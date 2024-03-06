using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.IRepositorio;
using Stripe;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepositorio _payment;

        public PaymentController(IPaymentRepositorio payment)
        {
            _payment = payment;
        }

        [HttpPost("checkout")]
        public ActionResult CreateCheckoutSession(List<ItemDTO> items) 
        {
            var url = _payment.CreateCheckoutSession(items);
            return Ok(url);
        }

        [HttpPost("checkout2")]
        public ActionResult CreateCheckoutSession2(List<ItemDTO> items)
        {
            var url = _payment.CreateCheckoutSession2(items);
            return Ok(url);
        }




    }
}
