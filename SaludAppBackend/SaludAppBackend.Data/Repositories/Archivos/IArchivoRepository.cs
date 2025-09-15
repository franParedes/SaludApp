using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Archivos
{
    public interface IArchivoRepository
    {
        Task AddArchivoAsync(TbArchivo archivo);
    }
}
