using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.RecepcionistaService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionsitasController : ControllerBase
    {
        private readonly IRecepcionistaService _recepcionistaService;
        private readonly ILogger<RecepcionsitasController> _logger;

        public RecepcionsitasController(IRecepcionistaService recepcionistaService, ILogger<RecepcionsitasController> logger)
        {
            _recepcionistaService = recepcionistaService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CrearRecepcionista")]
        public async Task<IActionResult> CrearNuevoRecepcionista([FromBody] RecepcionistaModel recepcionista)
        {
            try
            {
                _logger.LogInformation($"Recibida petición para crear nuevo recepcionista con cédula {recepcionista.Cedula}");

                var nuevoRecepcionista = await _recepcionistaService.CrearRecepcionistaAsync(recepcionista);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevoRecepcionista });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear el recepcionista con cédula {Cedula}", recepcionista.Cedula);
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
