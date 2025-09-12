using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Utilities
{
    public class UtilitiesRepository(AppDbContext context) : GenericRepository(context), IUtilitiesRepository
    {
        public async Task<IEnumerable<TbTipoUsuario>> GetTiposDeUsuarioAsync()
        {
            return await GetAllAsync<TbTipoUsuario>();
        }
    }
}
