using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<TbUsuario>> GetAllUsuariosSPAsync();
        Task<TbUsuario?> GetUsuarioByIdSPAsync(int idUsuario);
        Task<bool> CheckIfUserExistsAsync(string email);
    }
}
