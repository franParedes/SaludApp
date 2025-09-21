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
                Estado = "pendiente",
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

            //await _unitOfWork.Citas.AddCita(nuevaCita);
            await _unitOfWork.Citas.AddCitaLaboratorio(nuevaCitaLab);
            await _unitOfWork.CompleteAsync();

            return nuevaCitaLab.IdCitaLab;
        }

        public async Task<int> CrearNuevaCitaMedicaAsync(CitaMedicaModel citaMedica)
        {
            _logger.LogInformation("Creando nueva solicitud de cita médica");
            var pacienteExiste = await _unitOfWork.Pacientes.BuscarPacientePorIdAsync(citaMedica.PacienteId);

            if (pacienteExiste == 0)
                throw new InvalidOperationException($"El paciente con id {citaMedica.PacienteId} no existe");
            
            //Hay que cambiar esto para que asigne automáticamente el médico
            var medicoAsignar = await _unitOfWork.Medicos.AsignarMedicoAcita(citaMedica.Especialidad);

            if (medicoAsignar == 0)
                throw new InvalidOperationException($"No hay profesional disponible para esta especialidad");

            var nuevaCita = new TbCita
            {
                PacienteId = citaMedica.PacienteId,
                Lugar = citaMedica.Lugar,
                FechaSolicitud = citaMedica.FechaSolicitud,
                Estado = "pendiente",
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
                await _unitOfWork.Citas.AddCita(nuevaCita);
                await _unitOfWork.Citas.AddCitaMedica(nuevaCitaMedica);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return nuevaCitaMedica.IdCitaMedica;
        }
    }
}
