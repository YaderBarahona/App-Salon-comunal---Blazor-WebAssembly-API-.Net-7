using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        [HttpPost("validate-recaptcha")]
        public async Task<IActionResult> ValidateReCaptcha(ReCaptchaValidationRequest request)
        {
            var googleUrl = $"https://www.google.com/recaptcha/api/siteverify?secret={request.SecretKey}&response={request.ReCaptchaResponse}";

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(googleUrl, null);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(content);

                return Ok(reCaptchaResponse.Success);
            }

            return BadRequest("Error al validar el ReCaptcha.");
        }
    }

}
