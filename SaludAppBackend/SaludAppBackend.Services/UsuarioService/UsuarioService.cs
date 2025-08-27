using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUnitOfWork unitOfWork, ILogger<UsuarioService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> BuscarUsuarioPorCorre(string correo)
        {
            _logger.LogInformation($"Consultando si el usuario con correo {correo} existe");
            var usuarioExiste = await _unitOfWork.Usuarios.CheckIfUserExistsAsync(correo);

            return usuarioExiste;
        }
    }
}
