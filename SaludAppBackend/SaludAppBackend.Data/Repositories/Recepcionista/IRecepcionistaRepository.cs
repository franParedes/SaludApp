using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Recepcionista
{
    public interface IRecepcionistaRepository
    {
        Task AddRecepcionistaAsync(TbRecepcionista recepcionista);
    }
}
