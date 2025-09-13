using SaludAppBackend.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.MedicoService
{
    public interface IMedicoService
    {
        Task<int> CrearNuevoMedicoAsync(MedicoModel medico);
    }
}
