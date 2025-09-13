using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using SaludAppBackend.Data.Repositories.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Medicos
{
    public class MedicoRepository : GenericRepository, IMedicoRepository
    {
        private readonly ILogger<MedicoRepository> _logger;
        public MedicoRepository(AppDbContext context, ILogger<MedicoRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddMedicoAsync(TbMedico medico)
        {
            await _appDbContext.TbMedicos.AddAsync(medico);
        }
    }
}
