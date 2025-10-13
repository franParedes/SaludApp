using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.MedicoService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly ILogger<MedicosController> _logger;

        public MedicosController(IMedicoService medicoService, ILogger<MedicosController> logger)
        {
            _medicoService = medicoService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CrearMedico")]
        public async Task<IActionResult> CrearNuevoPaciente([FromBody] MedicoModel medico)
        {
            try
            {
                _logger.LogInformation($"Recibida petición para crear nuevo medico con código sanitario {medico.Cedula}");

                var nuevoMedico = await _medicoService.CrearNuevoMedicoAsync(medico);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevoMedico });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear el médico con cédula {Cedula}", medico.Cedula);
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
