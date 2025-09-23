using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;

namespace SaludAppBackend.Data.Repositories.Citas
{
    public class CitasRepository : GenericRepository, ICitasRepository
    {
        private readonly ILogger<CitasRepository> _logger;

        public CitasRepository(AppDbContext context, ILogger<CitasRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddCita(TbCita cita)
        {
            await _appDbContext.TbCitas.AddAsync(cita);
        }

        public async Task AddCitaLaboratorio(TbCitasLaboratorio citaLab)
        {
            await _appDbContext.TbCitasLaboratorios.AddAsync(citaLab);
        }

        public async Task AddCitaMedica(TbCitasMedica citaMedica)
        {
            await _appDbContext.TbCitasMedicas.AddAsync(citaMedica);
        }

        public void AprobarCita(int idCita, DateTime fechaCita)
        {
            /*
             solo una propiedad asignada: el Id del registro que quieres modificar. Esto es como decir 
             "yo ya sé cuál es la cita, solo necesito su Id para encontrarla".
             */
            var cita = new TbCita { IdCita = idCita };

            /*
             Esto le dice a Entity Framework: "Empieza a seguir este objeto para hacer cambios, pero 
             no asumas que es nuevo, porque este ya existe en la base de datos".
             */
            _appDbContext.TbCitas.Attach(cita);

            cita.Estado = "aprobada";
            cita.FechaCita = fechaCita;

            /*
             Especificamos las propiedades que se modificaron
             */
            _appDbContext.Entry(cita).Property(x => x.Estado).IsModified = true;
            _appDbContext.Entry(cita).Property(x => x.FechaCita).IsModified = true;
        }

        public void CambiarEstadoCita(string Estado, int idCita)
        {
            var cita = new TbCita { IdCita = idCita };

            _appDbContext.TbCitas.Attach(cita);
            cita.Estado = Estado;

            _appDbContext.Entry(cita).Property(x => x.Estado).IsModified = true;
        }

        public void RechazarCita(int idCita, string motivoRechazo)
        {
            var cita = new TbCita { IdCita= idCita };
            _appDbContext.TbCitas.Attach(cita);
            cita.Estado = "rechazada";
            cita.MotivoRechazo = motivoRechazo;

            _appDbContext.Entry(cita).Property(x => x.Estado).IsModified = true;
            _appDbContext.Entry(cita).Property(x => x.MotivoRechazo).IsModified = true;
        }
    }
}
