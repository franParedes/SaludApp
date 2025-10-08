using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.Usuarios;

namespace SaludAppBackend.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<int> BuscarUsuarioPorCorreo(string correo);
        Task<TbUsuario> CrearUsuario(UsuarioModel usuario);
        Task<TbPasswd> CrearPasswd(string passwd, TbUsuario usuario);
    }
}
