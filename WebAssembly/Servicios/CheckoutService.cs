using DTO;
using System.Text;
using System.Text.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class CheckoutService : ICheckoutService
    {
        private readonly HttpClient _httpClient;

        public CheckoutService(
            HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

        public async Task<string> Checkout(List<ItemDTO> items)
        {
            var jsonItems = JsonSerializer.Serialize(items);

            var content = new StringContent(jsonItems, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Payment/Checkout", content);

            var url = await response.Content.ReadAsStringAsync();

            return url;
        }

        public async Task<string> Checkout2(List<ItemDTO> items)
        {
            var jsonItems = JsonSerializer.Serialize(items);

            var content = new StringContent(jsonItems, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Payment/Checkout2", content);

            var url = await response.Content.ReadAsStringAsync();

            return url;
        }
    }
}
