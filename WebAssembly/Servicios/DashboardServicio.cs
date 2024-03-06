using DTO;
using System.Net.Http.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly HttpClient _httpClient;

        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>("Dashboard/Resumen");

        }
    }
}
