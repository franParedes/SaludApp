using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.RecepcionistasService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRegistroController : ControllerBase
    {
        private readonly IRegistroService _registroService;
        private readonly ILogger<UsuarioRegistroController> _logger;

        public UsuarioRegistroController(IRegistroService registroService, ILogger<UsuarioRegistroController> logger)
        {
            _registroService = registroService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CrearUsuarioDeRegistro")]
        public async Task<IActionResult> CrearNuevoUsuarioDeRegistro([FromBody] RegistroModel registro)
        {
            try
            {
                _logger.LogInformation($"Recibida petición para crear nuevo usuario de registro con cédula {registro.Cedula}");

                var nuevoUsuarioRegistro = await _registroService.AddUsuarioRegistroAsync(registro);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevoUsuarioRegistro });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear el usuario de registro con cédula {Cedula}", registro.Cedula);
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
