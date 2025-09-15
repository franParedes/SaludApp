using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Pacientes
{
    public class PacienteRepository : GenericRepository, IPacienteRepository
    {
        private readonly ILogger<PacienteRepository> _logger;

        public PacienteRepository(AppDbContext context, ILogger<PacienteRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddPacienteAsync(TbPaciente paciente)
        {
            await _appDbContext.TbPacientes.AddAsync(paciente);
        }

        public async Task<int> BuscarPacientePorIdAsync(int idPaciente)
        {
            try
            {
                var sql = "SELECT f_buscar_paciente_por_id(@IdPacienteParam)";
                var parameters = new { IdPacienteParam = idPaciente };

                return await ExecuteScalarAsync<int>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar comprobar la existencia del paciente");
                throw;
            }
        }
    }
}
