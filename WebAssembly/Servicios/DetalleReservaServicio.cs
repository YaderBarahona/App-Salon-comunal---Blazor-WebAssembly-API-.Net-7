using DTO;
using System.Net.Http.Json;
using WebAssembly.Servicios.IServicios;

namespace WebAssembly.Servicios
{
    public class DetalleReservaServicio : IDetalleReservaServicio
    {
        private readonly HttpClient _httpClient;

        public DetalleReservaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //public async Task<ResponseDTO<List<DetalleReservaDTO>>> ObtenerDetallesReserva(int idReserva)
        //{
        //    return await _httpClient.GetFromJsonAsync<ResponseDTO<List<DetalleReservaDTO>>>($"DetalleReserva/DetallesReserva/{idReserva}");
        //}

        public async Task<ResponseDTO<List<DetalleReservaDTO>>> ObtenerDetallesReserva(int idReserva)
        {
            var response = new ResponseDTO<List<DetalleReservaDTO>>();

            try
            {
                // Llamar al endpoint del API utilizando el ID de reserva proporcionado
                response = await _httpClient.GetFromJsonAsync<ResponseDTO<List<DetalleReservaDTO>>>($"DetalleReserva/DetallesReserva/{idReserva}");
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la solicitud
                response.Ok = false;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
