using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.IServicio;
using Utilidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail(MailRequest mail) {
            _emailSenderService.SendEmail(mail);
            return Ok();
        }
    }
}
