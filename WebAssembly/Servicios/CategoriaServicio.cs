using DTO;
using System.Net.Http.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly HttpClient _httpClient;

        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO categoria)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", categoria);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO categoria)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", categoria);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");

        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Lista/{buscar}");

        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obtener/{id}");
        }
    }
}
