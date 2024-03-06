namespace WebAssembly.Servicios.IServicios
{
    public interface IReCaptchaService
    {
        Task<bool> ValidateResponse(string recaptchaResponse, string secretKey);
    }
}
