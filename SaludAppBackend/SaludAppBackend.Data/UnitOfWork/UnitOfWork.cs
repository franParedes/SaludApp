using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Archivos;
using SaludAppBackend.Data.Repositories.Citas;
using SaludAppBackend.Data.Repositories.Medicos;
using SaludAppBackend.Data.Repositories.Pacientes;
using SaludAppBackend.Data.Repositories.Passwd;
using SaludAppBackend.Data.Repositories.Recepcionista;
using SaludAppBackend.Data.Repositories.Usuarios;
using SaludAppBackend.Data.Repositories.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        /*
            Para evitar el constructor gigante, usaremos el proveedor de servicios (IServiceProvider) 
            para que el UnitOfWork pueda "solicitar" un repositorio solo cuando se necesite. 
            Esto se llama Lazy Loading (carga perezosa).
         */
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<UnitOfWork> _logger;

        // Propiedades privadas para almacenar la instancia del repositorio una vez creada
        private IUsuarioRepository? _usuarios;
        private IPacienteRepository? _pacientes;
        private IMedicoRepository? _medicos;
        private IRecepcionistaRepository? _recepcionista;
        private IUtilitiesRepository? _utilities;
        private ICitasRepository? _citas;
        private IArchivoRepository? _archivos;
        private IPasswdRepository? _passwd;

        // Inyectamos el DbContext y el IServiceProvider
        public UnitOfWork(AppDbContext context, IServiceProvider serviceProvider, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        // Esta es la magia. El repositorio solo se crea la primera vez que se pide.
        /*
             Cuando agregues un nuevo repositorio:
             1. Agrega la propiedad a la interfaz IUnitOfWork.
             2. Agrega estos dos campos aquí:
                private IMedicoRepository? _medicos;
                public IMedicoRepository Medicos => _medicos ??= _serviceProvider.GetRequiredService<IMedicoRepository>();

            ¡El constructor no cambia!
         */
        public IUsuarioRepository Usuarios => _usuarios ??= _serviceProvider.GetRequiredService<IUsuarioRepository>();
        public IPacienteRepository Pacientes => _pacientes ??= _serviceProvider.GetRequiredService<IPacienteRepository>();
        public IMedicoRepository Medicos => _medicos ??= _serviceProvider.GetRequiredService<IMedicoRepository>();
        public IRecepcionistaRepository Recepcionistas => _recepcionista ??= _serviceProvider.GetRequiredService<IRecepcionistaRepository>();
        public IUtilitiesRepository Utilities => _utilities ??= _serviceProvider.GetRequiredService<IUtilitiesRepository>();
        public ICitasRepository Citas => _citas ??= _serviceProvider.GetRequiredService<ICitasRepository>();
        public IArchivoRepository Archivos => _archivos ??= _serviceProvider.GetRequiredService<IArchivoRepository>();
        public IPasswdRepository Passwd => _passwd ??= _serviceProvider.GetRequiredService<IPasswdRepository>();

        public async Task<int> CompleteAsync()
        {
            try
            {
                // Usamos EF Core solo para guardar cambios, importante porque nos brinda atomicidad
                var result = await _context.SaveChangesAsync();
                _logger.LogInformation($"Se guardaron {result} cambios en la base de datos.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException, ex.Message, "Ocurrió un error al intentar guardar los cambios en la base de datos (Commit).");
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
