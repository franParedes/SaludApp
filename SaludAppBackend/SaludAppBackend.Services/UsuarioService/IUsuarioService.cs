using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<bool> BuscarUsuarioPorCorre(string correo);
    }
}
