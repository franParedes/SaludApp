using SaludAppBackend.Data.Repositories.Administradores;
using SaludAppBackend.Data.Repositories.Archivos;
using SaludAppBackend.Data.Repositories.Citas;
using SaludAppBackend.Data.Repositories.Medicos;
using SaludAppBackend.Data.Repositories.Pacientes;
using SaludAppBackend.Data.Repositories.Passwd;
using SaludAppBackend.Data.Repositories.Recepcionista;
using SaludAppBackend.Data.Repositories.UsuarioRegistroRepository;
using SaludAppBackend.Data.Repositories.Usuarios;
using SaludAppBackend.Data.Repositories.Utilities;

namespace SaludAppBackend.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IPacienteRepository Pacientes { get; }
        IMedicoRepository Medicos { get; }
        IRecepcionistaRepository Recepcionistas { get; }
        IUsuarioRegistroRepository UsuarioRegistros { get; }
        IAdminRepository Administradores { get; }
        IUtilitiesRepository Utilities { get; }
        ICitasRepository Citas { get; }
        IArchivoRepository Archivos { get; }
        IPasswdRepository Passwd { get; }
        Task<int> CompleteAsync();
    }
}
