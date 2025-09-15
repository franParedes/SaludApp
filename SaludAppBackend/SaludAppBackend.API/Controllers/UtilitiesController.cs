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
                var tiposUsuario = await _utilitiesService.GetTiposDeUsuario();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los tipos de usuario");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerGeneros")]
        public async Task<IActionResult> GetGenerosAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetGenerosAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los géneros");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerProveedoresTelefonicos")]
        public async Task<IActionResult> GetProveedoresTelefonicoAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetProveedoresTelefonicoAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los proveedores telfónicos");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerDepartamentos")]
        public async Task<IActionResult> GetDepartamentosAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetDepartamentosAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los departamentos");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerMunicipios")]
        public async Task<IActionResult> GetMunicipiosAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetMunicipiosAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los municupios");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerBarrios")]
        public async Task<IActionResult> GetBarriosAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetBarriosAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los barrios");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerReligiones")]
        public async Task<IActionResult> GetReligionesAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetReligionesAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener las religiones");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerOcupacionesDePacientes")]
        public async Task<IActionResult> GetOcupacionesPacientesAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetOcupacionesPacientesAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener las ocupaciones de pacientes");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerEspecialidadesMedicas")]
        public async Task<IActionResult> GetEspecialidadesMedicasAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetEspecialidadesMedicasAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener las especialidades medicas");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerUniversidades")]
        public async Task<IActionResult> GetUniversidadesAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetUniversidadesAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener las universidades");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerAreasMedicas")]
        public async Task<IActionResult> GetAreasMedicasAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetAreasMedicasAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener las áreas médicas");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerCentrosMedicos")]
        public async Task<IActionResult> GetCentrosMedicosAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetCentrosMedicosAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los centros médicos");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerTurnosMedicos")]
        public async Task<IActionResult> GetTurnosMedicosAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetTurnosMedicosAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los turnos médicos");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerTipoDeCita")]
        public async Task<IActionResult> GetTipoDeCitasAsync()
        {
            try
            {
                var tiposUsuario = await _utilitiesService.GetTipoDeCitasAsync();
                return Ok(tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error inesperado al obtener los tipos de citas");
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
