using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.Administradores
{
    public class AdminRepository : GenericRepository, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AgregarAdminAsync(TbAdministrador administrador)
        {
            await _appDbContext.TbAdministradors.AddAsync(administrador);
        }
    }
}
