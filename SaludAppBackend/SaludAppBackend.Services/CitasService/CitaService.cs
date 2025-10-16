using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Citas;
using SaludAppBackend.Services.ArchivoService;

namespace SaludAppBackend.Services.CitasService
{
    public class CitaService : ICitaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArchivoService _archivoService;
        private readonly ILogger<CitaService> _logger;

        public CitaService(IUnitOfWork unitOfWork, IArchivoService archivoService, ILogger<CitaService> logger)
        {
            _unitOfWork = unitOfWork;
            _archivoService = archivoService;
            _logger = logger;
        }

        public async Task<bool> AprobarCita(int idCita, DateTime fechaCita)
        {
            _logger.LogInformation("Trantando de aprobar la cita {idCita} para la fecha {fechaCita}", idCita, fechaCita);

            try
            {
                _unitOfWork.Citas.AprobarCita(idCita, fechaCita);
                 var filasAfectadas = await _unitOfWork.CompleteAsync();

                return filasAfectadas > 0;
            } catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<bool> CambiarEstadoCita(int Estado, int idCita)
        {
            _logger.LogInformation("Intentando cambiar el estado de la cita con id {idCita}", idCita);
            try
            {
                _unitOfWork.Citas.CambiarEstadoCita(Estado, idCita);
                var filas = await _unitOfWork.CompleteAsync();

                return filas > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<int> CrearNuevaCitaDeLaboratorioAsync(CitaLaboratorioModel citaLaboratorio)
        {
            _logger.LogInformation("Creando nueva solicitud de cita de laboratorio");
            
            var pacienteExiste = await _unitOfWork.Pacientes.BuscarPacientePorIdAsync(citaLaboratorio.PacienteId);

            if (pacienteExiste == 0)
                throw new InvalidOperationException($"El paciente con id {citaLaboratorio.PacienteId} no existe");

            var nuevaCita = new TbCita
            {
                PacienteId = citaLaboratorio.PacienteId,
                Lugar = citaLaboratorio.Lugar,
                FechaSolicitud = citaLaboratorio.FechaSolicitud,
                Estado = 1,
                MotivoCita = citaLaboratorio.MotivoCita,
                TipoCita = citaLaboratorio.TipoCita
            };

            var nuevaCitaLab = new TbCitasLaboratorio
            {
                IdCitaNavigation = nuevaCita,
                ExamenesRealizar = string.Join(",", citaLaboratorio.ExamanesRealizar)
            };

            foreach(var adjunto in citaLaboratorio.Adjuntos)
            {
                var nuevoArchivo = await _archivoService.CrearEntidadArchivoAsync(adjunto);

                var nuevoArchivoLab = new TbArchivosCitasLab
                {
                    Archivo = nuevoArchivo,
                    Cita = nuevaCitaLab
                };

                nuevaCitaLab.TbArchivosCitasLabs.Add(nuevoArchivoLab);
            }

            try
            {
                await _unitOfWork.Citas.AddCitaLaboratorio(nuevaCitaLab);
                await _unitOfWork.CompleteAsync(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

            return nuevaCitaLab.IdCitaLab;
        }

        public async Task<int> CrearNuevaCitaMedicaAsync(CitaMedicaModel citaMedica)
        {
            _logger.LogInformation("Creando nueva solicitud de cita médica");
            var pacienteExiste = await _unitOfWork.Pacientes.BuscarPacientePorIdAsync(citaMedica.PacienteId);

            if (pacienteExiste == 0)
                throw new InvalidOperationException($"El paciente con id {citaMedica.PacienteId} no existe");
            
            var medicoAsignar = await _unitOfWork.Medicos.AsignarMedicoAcita(citaMedica.Especialidad);

            if (medicoAsignar == 0)
                throw new InvalidOperationException($"No hay profesional disponible para esta especialidad");

            var nuevaCita = new TbCita
            {
                PacienteId = citaMedica.PacienteId,
                Lugar = citaMedica.Lugar,
                FechaSolicitud = citaMedica.FechaSolicitud,
                Estado = 1,
                MotivoCita = citaMedica.MotivoCita,
                TipoCita = citaMedica.TipoCita
            };

            var nuevaCitaMedica = new TbCitasMedica
            {
                IdCitaNavigation = nuevaCita,
                MedicoId = medicoAsignar,
                Especialidad = citaMedica.Especialidad,
            };

            foreach (var adjunto in citaMedica.Adjuntos)
            {
                var nuevoArchivo = await _archivoService.CrearEntidadArchivoAsync(adjunto);
                var nuevoArchivoMed = new TbArchivosCitasMedica
                {
                    Archivo = nuevoArchivo,
                    Cita = nuevaCitaMedica
                };

                nuevaCitaMedica.TbArchivosCitasMedicas.Add(nuevoArchivoMed);
            }

            try
            {
                await _unitOfWork.Citas.AddCitaMedica(nuevaCitaMedica);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

            return nuevaCitaMedica.IdCitaMedica;
        }

        public async Task<bool> EliminarCitaLab(int idCitaLab)
        {
            _logger.LogInformation("Intentando eliminar la cita de laboratorio con id {idCita}", idCitaLab);
            try
            {
                _unitOfWork.Citas.EliminarCitaLab(idCitaLab);
                var filas = await _unitOfWork.CompleteAsync();

                return filas > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<bool> EliminarCitaMedica(int idCitaMedica)
        {
            _logger.LogInformation("Intentando eliminar la cita médica con id {idCita}", idCitaMedica);
            try
            {
                _unitOfWork.Citas.EliminarCitaMedica(idCitaMedica);
                var filas = await _unitOfWork.CompleteAsync();

                return filas > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<DetalleCitaLaboratorioModel?> ObtenerDetalleDeCitaLaboratorio(int idCita)
        {
            var cita = new DetalleCitaLaboratorioModel();
            try
            {
               cita = await _unitOfWork.Citas.ObtenerDetalleDeCitaLaboratorio(idCita);
                return cita;

            }
            catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<DetalleCitaMedicaModel?> ObtenerDetalleDeCitaMedica(int idCita)
        {
            var cita = new DetalleCitaMedicaModel();
            try
            {
                cita = await _unitOfWork.Citas.ObtenerDetalleDeCitaMedica(idCita);
                return cita;

            }
            catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<CitaPendienteModel>> ObtenerListaDeCitasPendientes()
        {
            IEnumerable<CitaPendienteModel> citasList = [];
            try
            {
                citasList = await _unitOfWork.Citas.ObtenerListaDeCitasPendientes();
                return citasList;
            } catch(Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }

        public async Task<bool> RechazarCita(int idCita, string motivoRechazo)
        {
            _logger.LogInformation("Intentando rechazar la cita con id {idCita}", idCita);
            try
            {
                _unitOfWork.Citas.RechazarCita(idCita, motivoRechazo);
                var filas = await _unitOfWork.CompleteAsync();

                return filas > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("{mensaje}", ex.Message);
                throw;
            }
        }
    }
}
