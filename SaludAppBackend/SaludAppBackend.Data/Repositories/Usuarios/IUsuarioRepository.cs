using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<TbUsuario>> GetAllUsuariosSPAsync();
        Task<TbUsuario?> GetUsuarioByIdSPAsync(int idUsuario);
        Task<int> BuscarUsuarioPorCorreo(string email);
        Task AddUsuarioAsync(TbUsuario usuario);
        Task<string> GetPasswordHashPorCorreo(string correo);
    }
}
