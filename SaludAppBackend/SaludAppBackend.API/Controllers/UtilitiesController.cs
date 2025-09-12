using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Services.PacienteService;
using SaludAppBackend.Services.UtilitiesService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilitiesService _utilitiesService;
        private readonly ILogger<UtilitiesController> _logger;

        public UtilitiesController(IUtilitiesService utilitiesService, ILogger<UtilitiesController> logger)
        {
            _utilitiesService = utilitiesService;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObtenerTipoDeUsuario")]
        public async Task<IActionResult> GetTiposDeUsuarioAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo tipos de usuario");

                var tiposUsuario = await _utilitiesService.GetTiposDeUsuario();

                // Devolvemos 201 Created y el objeto creado.
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los tipos de usuario");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
