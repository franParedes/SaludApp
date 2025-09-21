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

        public async Task<int> BuscarMedicoPorIdAsync(int idMedico)
        {
            try
            {
                var sql = "SELECT f_buscar_medico_por_id(@IdMedParam)";
                var parameters = new { IdMedParam = idMedico };

                return await ExecuteScalarAsync<int>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar comprobar la existencia del medico");
                throw;
            }
        }

        public async Task<int> AsignarMedicoAcita(int idEspecialidad)
        {
            try
            {
                var sql = "SELECT f_asignar_medico(@IdEspecialidad)";
                var parameters = new { IdEspecialidad = idEspecialidad };

                return await ExecuteScalarAsync<int>(sql, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar comprobar la existencia del medico");
                throw;
            }
        }
    }
}
