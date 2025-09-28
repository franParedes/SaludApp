using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Services.Autenticacion;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAutenticationService _authenticationService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAutenticationService authenticationService, ILogger<AuthController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpGet]
        [Route("VerificarCredenciales/{correo}/{password}")]
        public async Task<IActionResult> VerificarCredencialesAsync(string correo, string password)
        {
            try
            {
                var autenticacion = await _authenticationService.VerificarCredencialesAsync(correo, password);
                return Ok(autenticacion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al verificar credenciales");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
