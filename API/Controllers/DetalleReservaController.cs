using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.IServicio;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleReservaController : ControllerBase
    {
        private readonly IDetalleReservaServicio _detalleReservaServicio;


        public DetalleReservaController(IDetalleReservaServicio detalleReservaServicio)
        {
            _detalleReservaServicio = detalleReservaServicio;
        }

        //[HttpGet("DetallesReserva/{id:int}")]
        //public async Task<IActionResult> DetallesReserva(int id)
        //{
        //    var response = new ResponseDTO<List<DetalleReservaDTO>>();

        //    try
        //    {
        //        response.Ok = true;
        //        response.Resultado = await _detalleReservaServicio.ObtenerDetallesReserva(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Ok = false;
        //        response.Message = ex.Message;
        //    }

        //    return Ok(response);
        //}

        [HttpGet("DetallesReserva/{id:int}")]
        public async Task<IActionResult> DetallesReserva(int id)
        {
            var response = new ResponseDTO<List<DetalleReservaDTO>>();

            try
            {
                var detallesReserva = await _detalleReservaServicio.ObtenerDetallesReserva(id);

                if (detallesReserva == null || detallesReserva.Count == 0)
                {
                    // Si no se encontraron detalles de reserva, devuelve un estado 404 (No encontrado)
                    return NotFound();
                }

                response.Ok = true;
                response.Resultado = detallesReserva;
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }


    }
}
