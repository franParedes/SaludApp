using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
