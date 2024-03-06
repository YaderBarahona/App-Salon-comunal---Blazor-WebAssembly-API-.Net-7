using Blazored.LocalStorage;
using Blazored.Toast.Services;
using DTO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class ReservaServicio : IReservaServicio
    {
        private readonly HttpClient _httpClient;
        private ILocalStorageService _localStorageService;
        private IToastService _toastService;

        public ReservaServicio(HttpClient httpClient, ILocalStorageService localStorageService, IToastService toastService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _toastService = toastService;
        }


        public async Task<ResponseDTO<ReservaDTO>> Registrar(ReservaDTO reserva)
        {
            //esperando respuesta del endpoint
            //controlador/endpoint
            var response = await _httpClient.PostAsJsonAsync("Reserva/Registrar", reserva);

            //leyendo respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ReservaDTO>>();

            return result!;

        }


        public async Task<ResponseDTO<List<ReservaDTO>>> ReservasUsuario(int idUsuario)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ReservaDTO>>>($"Reserva/ReservasUsuario/{idUsuario}");
        }

        public async Task<ResponseDTO<bool>> ActualizarPago(int idReserva)
        {
            // Construir la URL con el ID de usuario
            string url = $"Reserva/ActualizarPago/{idReserva}";

            // Crear una solicitud HTTP PUT sin cuerpo
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            // Enviar la solicitud HTTP y esperar la respuesta
            var response = await _httpClient.SendAsync(request);

            // Leer y deserializar la respuesta
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task AgregarID(int idReserva)
        {
            try
            {
                // Guardar el id del producto en el local storage
                await _localStorageService.SetItemAsync("idReserva", idReserva);

                // Mostrar mensaje de éxito
                _toastService.ShowSuccess("Actualizando Reserva..");

            }
            catch (Exception)
            {
                _toastService.ShowError("error");
            }
        }

        public async Task<int?> ObtenerID()
        {

            // Obtener el ID del producto desde el local storage
            var idReserva = await _localStorageService.GetItemAsync<int?>("idReserva");
            return idReserva;


        }

        public async Task<ResponseDTO<List<ReservaDTO>>> Lista()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ReservaDTO>>>($"Reserva/Lista");

        }

    }
}
