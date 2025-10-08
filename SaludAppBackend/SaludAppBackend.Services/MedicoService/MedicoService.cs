using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.MedicoService
{
    public class MedicoService : IMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MedicoService> _logger;
        private readonly IUsuarioService _usuarioService;

        public MedicoService(IUnitOfWork unitOfWork, ILogger<MedicoService> logger, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public async Task<int> CrearNuevoMedicoAsync(MedicoModel medico)
        {
            _logger.LogInformation("Intentando agregar nuevo médico");

            var nuevoUsuario = await _usuarioService.CrearUsuario(medico);
            var nuevaContrasenya = await _usuarioService.CrearPasswd(medico.Contrasenya, nuevoUsuario);

            var nuevoMedico = new TbMedico
            {
                IdUsuarioNavigation = nuevoUsuario,
                CodSanitario        = medico.Cod_sanitario,
                Especialidad        = medico.Especialidad,
                EgresadoDe          = medico.EgresadoDe,
                EgresadoEl          = medico.EgresadoEl,
                ExperienciaAnyos    = medico.Experiencia_anyos,
                AreaActual          = medico.Area_actual,
                CentroActual        = medico.Centro_actual,
                TurnoActual         = medico.Turno_actual,
            };

            await _unitOfWork.Usuarios.AddUsuarioAsync( nuevoUsuario );
            await _unitOfWork.Passwd.AddPasswdAsync(nuevaContrasenya);
            await _unitOfWork.Medicos.AddMedicoAsync( nuevoMedico );

            await _unitOfWork.CompleteAsync();

            return nuevoMedico.IdMedico;
        }
    }
}
