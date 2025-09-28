using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Passwd
{
    public interface IPasswdRepository
    {
        Task AddPasswdAsync(TbPasswd passwd);
    }
}
