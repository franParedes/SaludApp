using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.Recepcionista
{
    public class RecepcionistaRepository : GenericRepository, IRecepcionistaRepository
    {
        private readonly ILogger<RecepcionistaRepository> _logger;

        public RecepcionistaRepository(AppDbContext context, ILogger<RecepcionistaRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddRecepcionistaAsync(TbRecepcionista recepcionista)
        {
            await _appDbContext.TbRecepcionistas.AddAsync(recepcionista);
        }
    }
}
