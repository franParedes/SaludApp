using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.AdministradoresRepository;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdminsService _adminsService;
        private readonly ILogger<AdministradoresController> _logger;

        public AdministradoresController(IAdminsService adminsService, ILogger<AdministradoresController> logger)
        {
            _adminsService = adminsService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CrearAdministrador")]
        public async Task<IActionResult> CrearNuevoAdministrador([FromBody] AdministradorModel administrador)
        {
            try
            {
                _logger.LogInformation($"Recibida petición para crear nuevo administrador con cédula {administrador.Cedula}");

                var nuevoAdmin = await _adminsService.CrearAdministradorAsync(administrador);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { id = nuevoAdmin });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al crear el administador con cédula {Cedula}", administrador.Cedula);
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
