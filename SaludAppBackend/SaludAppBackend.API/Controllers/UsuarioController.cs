using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Services.UsuarioService;

namespace SaludAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService usuarioService, ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpGet("GetUsuarioPorEmail/{correo}")]
        public async Task<IActionResult> GetUsuarioPorEmail(string correo)
        {
            try
            {
                var usuario = await _usuarioService.BuscarUsuarioPorCorreo(correo);
                if (usuario > 0)
                {
                    return Ok(new { existe = false });
                }

                return Ok(new { existe = true });
            } catch (Exception ex)
            {
                // Capturamos cualquier otro error inesperado
                _logger.LogError(ex, "Error inesperado al consultar usuario por correo.");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
