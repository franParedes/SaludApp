
using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.UsuarioRegistroRepository
{
    public interface IUsuarioRegistroRepository
    {
        Task AddUsuarioRegistroAsync(TbUsuarioRegistro registro);
    }
}
