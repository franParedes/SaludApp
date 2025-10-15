using Microsoft.AspNetCore.Mvc;
using SaludAppBackend.Models.Citas;
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
        public async Task<IActionResult> CrearNuevaCitaMedicaAsync([FromBody] CitaMedicaModel cita)
        {
            try
            {
                _logger.LogInformation("Recibida petición para agendar cita médica");

                var nuevaCitaMed = await _citaService.CrearNuevaCitaMedicaAsync(cita);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { idCitaMedica = nuevaCitaMed });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al crear cita médica: {message}", ex.Message);

                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpPost]
        [Route("AgendarCitaLaboratorio")]
        public async Task<IActionResult> CrearNuevaCitaDeLaboratorioAsync([FromBody] CitaLaboratorioModel cita)
        {
            try
            {
                _logger.LogInformation("Recibida petición para agendar cita de laboratorio");

                var nuevaCitaLab = await _citaService.CrearNuevaCitaDeLaboratorioAsync(cita);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(new { idCitaLaboratorio = nuevaCitaLab });
            }
            catch (InvalidOperationException ex)
            {
                // Capturamos errores de negocio, como cédula o correo duplicado.
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al crear cita de laboratorio: {message}", ex.Message);
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpPut]
        [Route("AprobarCita/{idCita}/{fechaCita}")]
        public async Task<IActionResult> AprobarCita(int idCita, DateTime fechaCita)
        {
            try
            {
                _logger.LogInformation("Recibida petición para aprobar cita");

                var citaAprobada = await _citaService.AprobarCita(idCita, fechaCita);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(citaAprobada);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al aprobar cita: {message}", ex.Message);

                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpPut]
        [Route("RechazarCita/{idCita}/{motivoRechazo}")]
        public async Task<IActionResult> RechazarCita(int idCita, string motivoRechazo)
        {
            try
            {
                _logger.LogInformation("Recibida petición para rechazar cita");

                var citaRechazada = await _citaService.RechazarCita(idCita, motivoRechazo);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(citaRechazada);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al rechazar cita: {message}", ex.Message);

                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpPut]
        [Route("CambiarEstadoCita/{idCita}/{estado}")]
        public async Task<IActionResult> CambiarEstadoCita(int idCita, int estado)
        {
            try
            {
                _logger.LogInformation("Recibida petición para cambiar estado de cita");

                var hecho = await _citaService.CambiarEstadoCita(estado, idCita);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(hecho);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al cambiar estado de cita: {message}", ex.Message);

                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpDelete]
        [Route("EliminarCitaMedica/{idCitaMedica}")]
        public async Task<IActionResult> EliminarCitaMedica(int idCitaMedica)
        {
            try
            {
                _logger.LogInformation("Recibida petición para elimnar cita médica");

                var hecho = await _citaService.EliminarCitaMedica(idCitaMedica);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(hecho);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al eliminar cita médica: {message}", ex.Message);

                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpDelete]
        [Route("EliminarCitaLaboratorio/{idCitaLab}")]
        public async Task<IActionResult> EliminarCitaLab(int idCitaLab)
        {
            try
            {
                _logger.LogInformation("Recibida petición para elimnar cita de laboratorio");

                var hecho = await _citaService.EliminarCitaLab(idCitaLab);

                // Devolvemos 201 Created y el objeto creado.
                return Ok(hecho);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al eliminar cita de laboratorio: {message}", ex.Message);

                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerListaDeCitasPendientes")]
        public async Task<IActionResult> ObtenerListaDeCitasPendientes()
        {
            try
            {
                _logger.LogInformation("Solicitud recibida para obtener lista de citas pendientes");
                var listaCitas = await _citaService.ObtenerListaDeCitasPendientes();
                _logger.LogInformation("Lista obtenida");
                return Ok(listaCitas);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al eliminar cita de laboratorio: {message}", ex.Message);

                return StatusCode(409 , "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerDetalleDeCitaMedica/{idCita}")]
        public async Task<IActionResult> ObtenerDetalleDeCitaMedica(int idCita)
        {
            try
            {
                _logger.LogInformation("Solicitud recibida para obtener el detalle de cita medica");
                var cita = await _citaService.ObtenerDetalleDeCitaMedica(idCita);
                _logger.LogInformation("Detalle obtenido");
                return Ok(cita);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al eliminar cita de laboratorio: {message}", ex.Message);

                return StatusCode(409, "Ocurrió un error interno en el servidor.");
            }
        }

        [HttpGet]
        [Route("ObtenerDetalleDeCitaLaboratorio/{idCita}")]
        public async Task<IActionResult> ObtenerDetalleDeCitaLaboratorio(int idCita)
        {
            try
            {
                _logger.LogInformation("Solicitud recibida para obtener el detalle de cita de lab");
                var cita = await _citaService.ObtenerDetalleDeCitaLaboratorio(idCita);
                _logger.LogInformation("Detalle obtenido");
                return Ok(cita);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(new { message = ex.Message }); // HTTP 409
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado al eliminar cita de laboratorio: {message}", ex.Message);

                return StatusCode(409, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
