using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.DTOs.AutenticacionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.Autenticacion
{
    public class AutenticationService : IAutenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AutenticationService> _logger;

        public AutenticationService(IUnitOfWork unitOfWork, ILogger<AutenticationService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<AutenticacionResponse> VerificarCredencialesAsync(string correo, string password)
        {
            int? Departamento = 0;
            int? Municipio = 0;
            int? Barrio = 0;

            _logger.LogInformation("Verificando credenciales para el correo {correo}", correo);
            try
            {
                var idUsuario = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(correo);
                var idPaciente = _unitOfWork.Pacientes.BuscarPacientePorIdUsuarioAsync(idUsuario);
                var usuario = await _unitOfWork.Usuarios.GetUsuarioByIdSPAsync(idUsuario);
                var hashPassword = await _unitOfWork.Usuarios.GetPasswordHashPorCorreo(correo);

                if (string.IsNullOrEmpty(hashPassword))
                {
                    _logger.LogWarning("Intento de login para un correo no existente: {Correo}", correo);
                    return new AutenticacionResponse(); // El usuario no existe.
                }

                bool esValida = BCrypt.Net.BCrypt.Verify(password, hashPassword);

                if (!esValida)
                {
                    _logger.LogWarning("Intento de login fallido (contraseña incorrecta) para: {Correo}", correo);
                    return new AutenticacionResponse();
                }

                // Forma más limpia de obtener la primera dirección
                var primeraDireccion = usuario!.TbDirecciones.FirstOrDefault();

                if (primeraDireccion != null)
                {
                    Departamento = primeraDireccion.Departamento;
                    Municipio = primeraDireccion.Municipio;
                    Barrio = primeraDireccion.Barrio;
                }

                return new AutenticacionResponse
                {
                    IdUsuario = usuario!.IdUsuario,
                    IdPaciente = idPaciente,
                    TipoUsuario = usuario.TipoUsuario,
                    Departamento = Departamento,
                    Municipio = Municipio,
                    Barrio = Barrio,
                    Verificado = 1
                };
            } catch (Exception ex)
            {
                _logger.LogError("Error en el servicio de autenticación, {message}", ex.Message);
                return new AutenticacionResponse();
            }
        }
    }
}
