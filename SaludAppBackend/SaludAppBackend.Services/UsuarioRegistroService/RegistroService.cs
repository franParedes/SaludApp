using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.RecepcionistasService;
using SaludAppBackend.Services.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.UsuarioRegistroService
{
    public class RegistroService : IRegistroService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RegistroService> _logger;
        private readonly IUsuarioService _usuarioService;

        public RegistroService(IUnitOfWork unitOfWork, ILogger<RegistroService> logger, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public async Task<int> AddUsuarioRegistroAsync(RegistroModel usuarioRegistro)
        {
            try
            {
                _logger.LogInformation("Intentando agregar usuario de registro");

                var nuevoUsuario = await _usuarioService.CrearUsuario(usuarioRegistro);
                var nuevaContrasenya = await _usuarioService.CrearPasswd(usuarioRegistro.Contrasenya, nuevoUsuario);

                var nuevoUsuarioRegistro = new TbUsuarioRegistro
                {
                    IdUsuarioNavigation = nuevoUsuario,
                    CentroActual = usuarioRegistro.CentroActual,
                    TurnoActual = usuarioRegistro.TurnoActual,
                };

                await _unitOfWork.Usuarios.AddUsuarioAsync(nuevoUsuario);
                await _unitOfWork.Passwd.AddPasswdAsync(nuevaContrasenya);
                await _unitOfWork.UsuarioRegistros.AddUsuarioRegistroAsync(nuevoUsuarioRegistro);

                await _unitOfWork.CompleteAsync();

                return nuevoUsuarioRegistro.IdRegistro;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear usuario de registro: {message}", ex.Message);
                return 0;
            }
        }
    }
}
