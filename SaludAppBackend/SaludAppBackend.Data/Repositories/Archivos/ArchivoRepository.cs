using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.Archivos
{
    public class ArchivoRepository : GenericRepository, IArchivoRepository
    {
        private readonly ILogger<ArchivoRepository> _logger;

        public ArchivoRepository(AppDbContext context, ILogger<ArchivoRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddArchivoAsync(TbArchivo archivo)
        {
            await _appDbContext.TbArchivos.AddAsync(archivo);
        }
    }
}
