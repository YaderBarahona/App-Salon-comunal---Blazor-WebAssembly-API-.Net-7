using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.IServicio;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardServicio _dashboardServicio;

        public DashboardController(IDashboardServicio dashboardServicio)
        {
            _dashboardServicio = dashboardServicio;
        }

        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.Ok = true;
                response.Resultado = _dashboardServicio.Resumen();
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
