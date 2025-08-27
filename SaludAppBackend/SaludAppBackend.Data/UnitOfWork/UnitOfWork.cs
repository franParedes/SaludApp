using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Usuarios;
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

        // Inyectamos el DbContext y el IServiceProvider
        public UnitOfWork(AppDbContext context, IServiceProvider serviceProvider, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        // Esta es la magia. El repositorio solo se crea la primera vez que se pide.
        public IUsuarioRepository Usuarios => _usuarios ??= _serviceProvider.GetRequiredService<IUsuarioRepository>();

        // Cuando agregues un nuevo repositorio:
        // 1. Agrega la propiedad a la interfaz IUnitOfWork.
        // 2. Agrega estos dos campos aquí:
        // private IMedicoRepository? _medicos;
        // public IMedicoRepository Medicos => _medicos ??= _serviceProvider.GetRequiredService<IMedicoRepository>();
        // ¡El constructor no cambia!

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
                _logger.LogError(ex, "Ocurrió un error al intentar guardar los cambios en la base de datos (Commit).");
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
