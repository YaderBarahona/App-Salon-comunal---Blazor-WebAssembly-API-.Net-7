using DTO;
using System.Net.Http.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly HttpClient _httpClient;

        public ProductoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO producto)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PostAsJsonAsync("Producto/Crear", producto);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(ProductoDTO producto)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PutAsJsonAsync("Producto/Editar", producto);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Lista/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Obtener/{id}");
        }
    }
}
