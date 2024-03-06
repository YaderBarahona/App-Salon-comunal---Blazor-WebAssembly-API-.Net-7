using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.IServicio;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServicio _reservaServicio;

        public ReservaController(IReservaServicio reservaServicio)
        {
            _reservaServicio = reservaServicio;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] ReservaDTO modelo)
        {
            var response = new ResponseDTO<ReservaDTO>();

            try
            {
                response.Ok = true;
                response.Resultado = await _reservaServicio.RegistrarReserva(modelo);
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                //throw;
            }

            return Ok(response);
        }

        [HttpPost("Registrar2")]
        public async Task<IActionResult> Registrar2([FromBody] ReservaDTO modelo)
        {
            var response = new ResponseDTO<ReservaDTO>();

            try
            {
                response.Ok = true;
                response.Resultado = await _reservaServicio.RegistrarReserva(modelo);
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                //throw;
            }

            return Ok(response);
        }

        [HttpGet("ReservasUsuario/{idUsuario?}")]
        public async Task<IActionResult> ReservasUsuario(int idUsuario)
        {
            var response = new ResponseDTO<List<ReservaDTO>>();

            try
            {
                response.Ok = true;
                response.Resultado = await _reservaServicio.ReservasUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                //throw;
            }

            return Ok(response);
        }

        [HttpPut("ActualizarPago/{id:int}")]
        public async Task<ActionResult> ActualizarPago(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.Ok = true;
                response.Resultado = await _reservaServicio.ActualizarPago(id);
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                //throw;
            }

            return Ok(response);
        }
        
        [HttpGet("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDTO<List<ReservaDTO>>();

            try
            {

                response.Ok = true;
                response.Resultado = await _reservaServicio.Lista();
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                //throw;
            }

            return Ok(response);
        }
    }
}
