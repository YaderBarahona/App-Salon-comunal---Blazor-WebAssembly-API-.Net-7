using DTO;
using System.Net.Http.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        //variable para las solicitudes httpclient
        private readonly HttpClient _httpClient;

        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO model)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", model);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO usuario)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", usuario);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO usuario)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", usuario);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            //retornano la respuesta al ejecutar el endpoint
            //pasando el id en la ruta
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");

        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");

        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{id}");
        }
    }
}
