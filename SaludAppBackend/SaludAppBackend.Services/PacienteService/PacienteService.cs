using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;

namespace SaludAppBackend.Services.PacienteService
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PacienteService> _logger;

        public PacienteService(IUnitOfWork unitOfWork, ILogger<PacienteService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> CrearNuevoPacienteAsync(PacienteModel paciente)
        {
            _logger.LogInformation("Intentando agregar nuevo paciente");
            var usuarioExiste = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(paciente.GeneralInfo.Correo);

            if (usuarioExiste > 0)
                throw new InvalidOperationException($"El paciente con correo {paciente.GeneralInfo.Correo} ya existe");

            string userName = $"@{paciente.GeneralInfo.PrimerNombre!.Substring(0, 1)}{paciente.GeneralInfo.PrimerApellido}";
            var nuevoUsuario = new TbUsuario
            {
                Username           = userName,
                Cedula             = paciente.GeneralInfo.Cedula,
                PrimerNombre       = paciente.GeneralInfo.PrimerNombre,
                SegundoNombre      = paciente.GeneralInfo.SegundoNombre,
                PrimerApellido     = paciente.GeneralInfo.PrimerApellido,
                SegundoApellido    = paciente.GeneralInfo.SegundoApellido,
                Correo             = paciente.GeneralInfo.Correo,
                Genero             = paciente.GeneralInfo.Genero,
                FechaNacimiento    = paciente.GeneralInfo.FechaNacimiento,
                TipoUsuario        = paciente.GeneralInfo.TipoUsuario,
                FechaCreacion      = DateOnly.FromDateTime(DateTime.Now),
                FechaActualizacion = DateOnly.FromDateTime(DateTime.Now),
                Activo             = true
            };

            string passwrodHsh = BCrypt.Net.BCrypt.HashPassword(paciente.GeneralInfo.Contrasenya);
            var nuevaContrasenya = new TbPasswd
            { 
                HashPasswd = passwrodHsh,
                IdUsuarioNavigation = nuevoUsuario
            };

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

            foreach (var tel in paciente.Telefonos)
            {
                nuevoUsuario.TbTelefonos.Add(
                    new TbTelefono { Telefono = tel.Telefono, Compania = tel.Compania }
                );
            }

            foreach (var dir in paciente.Direcciones)
            {
                nuevoUsuario.TbDirecciones.Add(
                    new TbDireccione
                    {
                        Departamento = dir.Departamento,
                        Municipio    = dir.Municipio,
                        Barrio       = dir.Barrio,
                        Direccion    = dir.Direccion
                    }
                );
            }

            await _unitOfWork.Usuarios.AddUsuarioAsync(nuevoUsuario);
            await _unitOfWork.Passwd.AddPasswdAsync(nuevaContrasenya);
            await _unitOfWork.Pacientes.AddPacienteAsync(nuevoPaciente);

            await _unitOfWork.CompleteAsync();

            return nuevoPaciente.IdPaciente;
        }
    }
}
