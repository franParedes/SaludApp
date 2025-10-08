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

namespace SaludAppBackend.Services.AdministradoresRepository
{
    public class AdminsService : IAdminsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminsService> _logger;
        private readonly IUsuarioService _usuarioService;

        public AdminsService(IUnitOfWork unitOfWork, ILogger<AdminsService> logger, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public async Task<int> CrearAdministradorAsync(AdministradorModel administrador)
        {
            try
            {
                _logger.LogInformation("Intentando agregar administrador");
                var nuevoUsuario = await _usuarioService.CrearUsuario(administrador);
                var nuevaContrasenya = await _usuarioService.CrearPasswd(administrador.Contrasenya, nuevoUsuario);

                var nuevoAdministrador = new TbAdministrador
                {
                    IdUsuarioNavigation = nuevoUsuario,
                    CentroActual = administrador.CentroActual
                };

                await _unitOfWork.Usuarios.AddUsuarioAsync(nuevoUsuario);
                await _unitOfWork.Passwd.AddPasswdAsync(nuevaContrasenya);
                await _unitOfWork.Administradores.AgregarAdminAsync(nuevoAdministrador);

                await _unitOfWork.CompleteAsync();

                return nuevoAdministrador.IdAdmin;

            } catch (Exception ex)
            {
                _logger.LogError("Error al crear administrador: {message}", ex.Message);
                return 0;
            }
        }
    }
}
