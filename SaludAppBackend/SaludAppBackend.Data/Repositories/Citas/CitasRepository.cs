using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using SaludAppBackend.Models.Citas;

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

            cita.Estado = 1;
            cita.FechaCita = fechaCita;

            /*
             Especificamos las propiedades que se modificaron
             */
            _appDbContext.Entry(cita).Property(x => x.Estado).IsModified = true;
            _appDbContext.Entry(cita).Property(x => x.FechaCita).IsModified = true;
        }

        public void CambiarEstadoCita(int Estado, int idCita)
        {
            var cita = new TbCita { IdCita = idCita };

            _appDbContext.TbCitas.Attach(cita);
            cita.Estado = Estado;

            _appDbContext.Entry(cita).Property(x => x.Estado).IsModified = true;
        }

        public void EliminarCitaLab(int idCitaLab)
        {
            var cita = new TbCitasLaboratorio { IdCitaLab = idCitaLab };
            _appDbContext.Entry(cita).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void EliminarCitaMedica(int idCitaMedica)
        {
            var cita = new TbCitasMedica { IdCitaMedica = idCitaMedica };
            _appDbContext.Entry(cita).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public async Task<DetalleCitaLaboratorioModel> ObtenerDetalleDeCitaLaboratorio(int idCita)
        {
            try
            {
                return (DetalleCitaLaboratorioModel)
                    await QuerySPAsync<DetalleCitaLaboratorioModel>("sp_detalle_cita_laboratorio",
                    new { Id_cita = idCita });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar obtener el detalle de la cita {cita}", idCita);
                throw;
            }
        }

        public async Task<DetalleCitaMedicaModel> ObtenerDetalleDeCitaMedica(int idCita)
        {
            try
            {
                return (DetalleCitaMedicaModel)
                    await QuerySPAsync<DetalleCitaMedicaModel>("sp_detalle_cita_medica",
                    new { Id_cita = idCita });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar obtener el detalle de la cita {cita}", idCita);
                throw;
            }
        }

        public async Task<IEnumerable<CitaPendienteModel>> ObtenerListaDeCitasPendientes()
        {
            try
            {
                return await QuerySPAsync<CitaPendienteModel>("sp_citas_pendientes_aprobacion", new { });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar obtener las citas pendientes de aprobación");
                throw;
            }
        }

        public void RechazarCita(int idCita, string motivoRechazo)
        {
            var cita = new TbCita { IdCita= idCita };
            _appDbContext.TbCitas.Attach(cita);
            cita.Estado = 3;
            cita.MotivoRechazo = motivoRechazo;

            _appDbContext.Entry(cita).Property(x => x.Estado).IsModified = true;
            _appDbContext.Entry(cita).Property(x => x.MotivoRechazo).IsModified = true;
        }
    }
}
