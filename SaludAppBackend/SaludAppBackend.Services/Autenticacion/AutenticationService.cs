using Microsoft.Extensions.Logging;
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
            _logger.LogInformation("Verificando credenciales para el correo {correo}", correo);
            try
            {
                var idUsuario = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(correo);
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

                return new AutenticacionResponse
                {
                    IdUsuario = usuario!.IdUsuario,
                    TipoUsuario = usuario.TipoUsuario,
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
