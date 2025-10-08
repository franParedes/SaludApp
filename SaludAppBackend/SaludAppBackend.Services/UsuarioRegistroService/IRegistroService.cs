using SaludAppBackend.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.RecepcionistasService
{
    public interface IRegistroService
    {
        Task<int> AddUsuarioRegistroAsync(RegistroModel usuarioRegistro);
    }
}
