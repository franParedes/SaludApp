using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.Archivos;

namespace SaludAppBackend.Services.ArchivoService
{
    public interface IArchivoService
    {
        Task<TbArchivo> CrearEntidadArchivoAsync(ArchivoBaseModel adjunto);
    }
}
