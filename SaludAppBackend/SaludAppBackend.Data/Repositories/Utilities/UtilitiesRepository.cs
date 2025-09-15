using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Utilities
{
    public class UtilitiesRepository(AppDbContext context) : GenericRepository(context), IUtilitiesRepository
    {
        public async Task<IEnumerable<TbAreasMedica>> GetAreasMedicasAsync() 
            => await GetAllAsync<TbAreasMedica>();

        public async Task<IEnumerable<TbBarrio>> GetBarriosAsync() 
            => await GetAllAsync<TbBarrio>();

        public async Task<IEnumerable<TbCentrosMedico>> GetCentrosMedicosAsync()
            => await GetAllAsync<TbCentrosMedico>();

        public async Task<IEnumerable<TbDepartamento>> GetDepartamentosAsync()
            => await GetAllAsync<TbDepartamento>();

        public async Task<IEnumerable<TbEspecialidade>> GetEspecialidadesMedicasAsync()
            => await GetAllAsync<TbEspecialidade>();

        public async Task<IEnumerable<TbGenero>> GetGenerosAsync()
            => await GetAllAsync<TbGenero>();

        public async Task<IEnumerable<TbMunicipio>> GetMunicipiosAsync()
            => await GetAllAsync<TbMunicipio>();

        public async Task<IEnumerable<TbOcupacione>> GetOcupacionesPacientesAsync()
            => await GetAllAsync<TbOcupacione>();

        public async Task<IEnumerable<TbProvTelefonico>> GetProveedoresTelefonicoAsync()
            => await GetAllAsync<TbProvTelefonico>();

        public async Task<IEnumerable<TbReligione>> GetReligionesAsync()
            => await GetAllAsync<TbReligione>();

        public async Task<IEnumerable<TbTipoUsuario>> GetTiposDeUsuarioAsync()
            => await GetAllAsync<TbTipoUsuario>();

        public async Task<IEnumerable<TbTurnosMedico>> GetTurnosMedicosAsync()
            => await GetAllAsync<TbTurnosMedico>();

        public async Task<IEnumerable<TbUniversidade>> GetUniversidadesAsync()
            => await GetAllAsync<TbUniversidade>();

        public async Task<IEnumerable<TbTiposCita>> GetTipoDeCitasAsync()
            => await GetAllAsync<TbTiposCita>();
    }
}
