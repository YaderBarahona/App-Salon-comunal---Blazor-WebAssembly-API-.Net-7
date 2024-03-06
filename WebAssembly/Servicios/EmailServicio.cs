using DTO;
using System.Net.Http.Json;
using Utilidades;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class EmailServicio : IEmailServicio
    {
        private readonly HttpClient _httpClient;

        public EmailServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task SendEmailAsync(MailRequest mail)
        {
            await _httpClient.PostAsJsonAsync("Email/SendEmail", mail);
        }
    }
}
