using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;
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

        public MedicoService(IUnitOfWork unitOfWork, ILogger<MedicoService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> CrearNuevoMedicoAsync(MedicoModel medico)
        {
            _logger.LogInformation("Intentando agregar nuevo médico");
            var usuarioExiste = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(medico.GeneralInfo.Correo);
            if (usuarioExiste > 0)
                throw new InvalidOperationException($"El médico con correo {medico.GeneralInfo.Correo} ya existe");

            string userName = $"@{medico.GeneralInfo.PrimerNombre!.Substring(0, 1)}{medico.GeneralInfo.PrimerApellido}";
            var nuevoUsuario = new TbUsuario
            {
                Username           = userName,
                Cedula             = medico.GeneralInfo.Cedula,
                PrimerNombre       = medico.GeneralInfo.PrimerNombre,
                SegundoNombre      = medico.GeneralInfo.SegundoNombre,
                PrimerApellido     = medico.GeneralInfo.PrimerApellido,
                SegundoApellido    = medico.GeneralInfo.SegundoApellido,
                Correo             = medico.GeneralInfo.Correo,
                Genero             = medico.GeneralInfo.Genero,
                FechaNacimiento    = medico.GeneralInfo.FechaNacimiento,
                TipoUsuario        = medico.GeneralInfo.TipoUsuario,
                FechaCreacion      = DateOnly.FromDateTime(DateTime.Now),
                FechaActualizacion = DateOnly.FromDateTime(DateTime.Now),
                Activo             = true
            };

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

            foreach (var tel in medico.Telefonos)
            {
                nuevoUsuario.TbTelefonos.Add(
                    new TbTelefono { Telefono = tel.Telefono, Compania = tel.Compania }
                );
            }

            await _unitOfWork.Usuarios.AddUsuarioAsync( nuevoUsuario );
            await _unitOfWork.Medicos.AddMedicoAsync( nuevoMedico );

            await _unitOfWork.CompleteAsync();

            return nuevoMedico.IdMedico;
        }
    }
}
