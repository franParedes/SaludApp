using SaludAppBackend.Models.Usuarios;

namespace SaludAppBackend.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<int> BuscarUsuarioPorCorreo(string correo);
    }
}
