using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.PacienteService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly ILogger<PacientesController> _logger;

        public PacientesController(IPacienteService pacienteService, ILogger<PacientesController> logger)
        {
            _pacienteService = pacienteService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CrearPaciente")]
        public async Task<IActionResult> CrearNuevoPaciente([FromBody] PacienteModel paciente)
        {
            try
            {
                _logger.LogInformation($"Recibida petición para crear nuevo paciente con cédula {paciente.Cedula}");

                var nuevoPaciente = await _pacienteService.CrearNuevoPacienteAsync(paciente);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevoPaciente });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear el paciente con cédula {Cedula}", paciente.Cedula);
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
