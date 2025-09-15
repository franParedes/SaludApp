using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Models.Citas;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.CitasService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;
        private readonly ILogger<CitasController> _logger;

        public CitasController(ICitaService citaService, ILogger<CitasController> logger)
        {
            _citaService = citaService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AgendarCitaMedica")]
        public async Task<IActionResult> CrearNuevoPaciente([FromBody] CitaMedicaModel cita)
        {
            try
            {
                _logger.LogInformation("Recibida petición para agendar cita médica");

                var nuevaCitaMed = await _citaService.CrearNuevaCitaMedicaAsync(cita);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevaCitaMed });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear cita médica");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpPost]
        [Route("AgendarCitaLaboratorio")]
        public async Task<IActionResult> CrearNuevoPaciente([FromBody] CitaLaboratorioModel cita)
        {
            try
            {
                _logger.LogInformation("Recibida petición para agendar cita de laboratorio");

                var nuevaCitaLab = await _citaService.CrearNuevaCitaDeLaboratorioAsync(cita);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevaCitaLab });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear cita de laboratorio");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
