using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.UsuarioService;

namespace SaludAppBackend.Services.RecepcionistaService
{
    public class RecepcionistaService : IRecepcionistaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RecepcionistaService> _logger;
        private readonly IUsuarioService _usuarioService;

        public RecepcionistaService(IUnitOfWork unitOfWork, ILogger<RecepcionistaService> logger, IUsuarioService usuarioService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public async Task<int> CrearRecepcionistaAsync(RecepcionistaModel recepcionista)
        {
            try
            {
                _logger.LogInformation("Intentando agregar recepcionista");
                
                var nuevoUsuario = await _usuarioService.CrearUsuario(recepcionista);
                var nuevaContrasenya = await _usuarioService.CrearPasswd(recepcionista.Contrasenya, nuevoUsuario);

                var nuevoRecepcionista = new TbRecepcionista
                {
                    IdUsuarioNavigation = nuevoUsuario,
                    CentroActual = recepcionista.CentroActual,
                    TurnoActual = recepcionista.TurnoActual,
                };

                await _unitOfWork.Usuarios.AddUsuarioAsync(nuevoUsuario);
                await _unitOfWork.Passwd.AddPasswdAsync(nuevaContrasenya);
                await _unitOfWork.Recepcionistas.AddRecepcionistaAsync(nuevoRecepcionista);

                await _unitOfWork.CompleteAsync();

                return nuevoRecepcionista.IdRecep;

            } catch (Exception ex)
            {
                _logger.LogError("Error al crear recepcionista: {message}", ex.Message);
                return 0;
            }
        }
    }
}
