using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.UsuarioService;

namespace SaludAppBackend.Services.PacienteService
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PacienteService> _logger;
        private readonly IUsuarioService _usuarioService;

        public PacienteService(IUnitOfWork unitOfWork, ILogger<PacienteService> logger, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public async Task<int> CrearNuevoPacienteAsync(PacienteModel paciente)
        {
            _logger.LogInformation("Intentando agregar nuevo paciente");
            
            var nuevoUsuario = await _usuarioService.CrearUsuario(paciente);
            var nuevaContrasenya = await _usuarioService.CrearPasswd(paciente.Contrasenya, nuevoUsuario);

            var nuevoPaciente = new TbPaciente
            {
                NumeroInss          = paciente.NumeroInss,
                Ocupacion           = paciente.Ocupacion,
                Escolaridad         = paciente.Escolaridad,
                Religion            = paciente.Religion,
                Edad                = paciente.Edad,
                EstadoCivil         = paciente.EstadoCivil,
                CantidadHermanos    = paciente.CantidadHermanos,
                IdUsuarioNavigation = nuevoUsuario
            };

            await _unitOfWork.Usuarios.AddUsuarioAsync(nuevoUsuario);
            await _unitOfWork.Passwd.AddPasswdAsync(nuevaContrasenya);
            await _unitOfWork.Pacientes.AddPacienteAsync(nuevoPaciente);

            await _unitOfWork.CompleteAsync();

            return nuevoPaciente.IdPaciente;
        }

        public async Task<InformacionGeneralPacienteModel?> ObtenerInformacionGeneralPaciente(int idUsuario)
        {
            var infoPaciente = new InformacionGeneralPacienteModel();
            try
            {
                infoPaciente = await _unitOfWork.Pacientes.ObtenerInformacionGeneralPaciente(idUsuario);
                return infoPaciente;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro en el servicio de pacientes {message}", ex.Message);
                return infoPaciente;
            }
        }
    }
}
