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
        Task<int> CompleteAsync();
    }
}
