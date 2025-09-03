using SaludAppBackend.Data.Repositories.Pacientes;
using SaludAppBackend.Data.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IPacienteRepository Pacientes { get; }
        Task<int> CompleteAsync();
    }
}
