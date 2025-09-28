using Serilog.Events;
using Serilog;
using SaludAppBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Data.Repositories.Usuarios;
using SaludAppBackend.Services.UsuarioService;
using SaludAppBackend.Data.Repositories.Pacientes;
using SaludAppBackend.Services.PacienteService;
using SaludAppBackend.Data.Repositories.Utilities;
using SaludAppBackend.Services.UtilitiesService;
using SaludAppBackend.Data.Repositories.Medicos;
using SaludAppBackend.Services.MedicoService;
using SaludAppBackend.Data.Repositories.Citas;
using SaludAppBackend.Services.CitasService;
using SaludAppBackend.Data.Repositories.Archivos;
using SaludAppBackend.Services.ArchivoService;
using SaludAppBackend.Services.Autenticacion;
using SaludAppBackend.Data.Repositories.Passwd;

namespace SaludAppBackend.API.ContenedorDepenConfig
{
    public static class ServiceCollectionConfiguration
    {
        public static void ConfigureServiceCollection(this IServiceCollection services,
                                                      IConfiguration configuration,
                                                      IHostEnvironment hostEnviroment)
        {
            services.AddControllers() //Registra servicios necesarios para usar los controladores
            .AddJsonOptions(options => //Es para convertir objetos c# a JSON y viceversa
            {
                // Desactiva la política de nombres, para que no los cruce a camelCase
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //Configurando Serilog para llevar registros de fallos o cualquier evento
            bool logEnabled = ConfigureSerilogLoggerServices(configuration);

            if (logEnabled)
            {
                //Registrando Serilog dentro del contenedor de dependencias del proyecto
                var serviceProvider = services.BuildServiceProvider();
                var _logger = serviceProvider.GetService<ILogger<Program>>();

                _logger!.LogInformation("Configuración inicial del Logger establecida correctamente.");

                //Registrando EntityFrameworkCore en el contenedor de dependencias
                services.AddDbContext<AppDbContext>(options => 
                    options.UseMySql(configuration.GetConnectionString("DefaultConnection"), 
                        ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")
                    )
                ));

                //Registrando repositorios
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<IUsuarioRepository, UsuarioRepository>();
                services.AddScoped<IPacienteRepository, PacienteRepository>();
                services.AddScoped<IMedicoRepository, MedicoRepository>();
                services.AddScoped<IUtilitiesRepository, UtilitiesRepository>();
                services.AddScoped<ICitasRepository, CitasRepository>();
                services.AddScoped<IArchivoRepository, ArchivoRepository>();
                services.AddScoped<IPasswdRepository, PasswdRepository>();

                //Registrando servicios
                services.AddScoped<IUsuarioService, UsuarioService>();
                services.AddScoped<IPacienteService, PacienteService>();
                services.AddScoped<IMedicoService, MedicoService>();
                services.AddScoped<IUtilitiesService, UtilitiesService>();
                services.AddScoped<ICitaService, CitaService>();
                services.AddScoped<IArchivoService, ArchivoService>();
                services.AddScoped<IAutenticationService, AutenticationService>();
            }
        }

        private static bool ConfigureSerilogLoggerServices(IConfiguration configuration)
        {
            bool logEnabled = false;

            //Esto recupera valores del fichero appsettings.json
            var logPath = configuration.GetValue<string>("LogPath");
            var logLevelMin = configuration.GetValue<string>("LogLevelMin");

            if (logPath != null && logLevelMin != null)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug() //Captura todos los mensajes a partir del nivel debugger

                    /*Cambia el nivel de log de las bibliotecas de microsoft y system a warning
                     esto para reducir la especificidad de los logs o sea, que no se haga tan grande*/
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .Enrich.FromLogContext() //Permite agregar contexto adicional a los logs

                    /*
                      path: logPath -> Crea un archivo nuevo cada día
                      retainedFileCountLimit: 30 -> Conserva el archivo máximo por 30 días
                     */
                    .WriteTo.File(path: logPath, 
                                  rollingInterval: RollingInterval.Day, 
                                  shared: true, 
                                  retainedFileCountLimit: 30)
                    .CreateLogger(); //Crea y asigna la configuración del logger a la variable global Log.Logger.

                logEnabled = true;
            }

            return logEnabled;
        }
    }
}
