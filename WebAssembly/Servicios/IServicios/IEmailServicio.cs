using DTO;
using Utilidades;

namespace WebAssembly.Servicios.IServicios
{
    public interface IEmailServicio
    {
        Task SendEmailAsync(MailRequest request);

    }
}
