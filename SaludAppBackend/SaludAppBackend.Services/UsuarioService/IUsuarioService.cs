using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.Usuarios;
using SaludAppBackend.Services.DTOs.UsuariosDTO;

namespace SaludAppBackend.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<int> BuscarUsuarioPorCorreo(string correo);
        Task<TbUsuario> CrearUsuario(UsuarioModel usuario);
        Task<TbPasswd> CrearPasswd(string passwd, TbUsuario usuario);
        Task<IEnumerable<UsuarioPorTipoDTO>> GetAllUsuariosPorTipo(int tipoDeUsuario);
    }
}
