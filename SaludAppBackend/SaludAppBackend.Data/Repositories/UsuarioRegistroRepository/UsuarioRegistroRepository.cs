using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.UsuarioRegistroRepository
{
    public class UsuarioRegistroRepository : GenericRepository, IUsuarioRegistroRepository
    {
        private readonly ILogger<UsuarioRegistroRepository> _logger;

        public UsuarioRegistroRepository(AppDbContext context, ILogger<UsuarioRegistroRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddUsuarioRegistroAsync(TbUsuarioRegistro registro)
        {
            await _appDbContext.TbUsuarioRegistros.AddAsync(registro);
        }
    }
}
