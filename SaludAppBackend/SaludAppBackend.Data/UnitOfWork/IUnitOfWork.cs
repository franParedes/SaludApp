using SaludAppBackend.Data.Repositories.Archivos;
using SaludAppBackend.Data.Repositories.Citas;
using SaludAppBackend.Data.Repositories.Medicos;
using SaludAppBackend.Data.Repositories.Pacientes;
using SaludAppBackend.Data.Repositories.Usuarios;
using SaludAppBackend.Data.Repositories.Utilities;
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
        IMedicoRepository Medicos { get; }
        IUtilitiesRepository Utilities { get; }
        ICitasRepository Citas { get; }
        IArchivoRepository Archivos { get; }
        Task<int> CompleteAsync();
    }
}
