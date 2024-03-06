using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Utilidades;
using WebAssembly.Servicios.IServicios;
using WebAssembly.Utilidades;

namespace WebAssembly.Servicios
{
    public class ReCaptchaService : IReCaptchaService
    {
           private readonly HttpClient _httpClient;

            public ReCaptchaService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<bool> ValidateResponse(string reCaptchaResponse, string secretKey)
            {
                var request = new ReCaptchaValidationRequest
                {
                    ReCaptchaResponse = reCaptchaResponse,
                    SecretKey = secretKey
                };

                var response = await _httpClient.PostAsJsonAsync("captcha/validate-recaptcha", request);

                return response.IsSuccessStatusCode && await response.Content.ReadFromJsonAsync<bool>();
            }
    }
}
