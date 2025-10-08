using SaludAppBackend.Models.Usuarios;

namespace SaludAppBackend.Services.RecepcionistaService
{
    public interface IRecepcionistaService
    {
        Task<int> CrearRecepcionistaAsync(RecepcionistaModel recepcionista);
    }
}
