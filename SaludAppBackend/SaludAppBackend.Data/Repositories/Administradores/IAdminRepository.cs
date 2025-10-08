using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Administradores
{
    public interface IAdminRepository
    {
        Task AgregarAdminAsync(TbAdministrador administrador);
    }
}
