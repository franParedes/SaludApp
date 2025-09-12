using SaludAppBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Utilities
{
    public interface IUtilitiesRepository
    {
        Task<IEnumerable<TbTipoUsuario>> GetTiposDeUsuarioAsync();

        //Métodos de pacientes
        Task<IEnumerable<TbGenero>> GetGenerosAsync();
        Task<IEnumerable<TbProvTelefonico>> GetProveedoresTelefonicoAsync();
        Task<IEnumerable<TbDepartamento>> GetDepartamentosAsync();
        Task<IEnumerable<TbMunicipio>> GetMunicipiosAsync();
        Task<IEnumerable<TbBarrio>> GetBarriosAsync();
        Task<IEnumerable<TbReligione>> GetReligionesAsync();
        Task<IEnumerable<TbOcupacione>> GetOcupacionesPacientesAsync();

        //Métodos de médicos
        Task<IEnumerable<TbEspecialidade>> GetEspecialidadesMedicasAsync();
        Task<IEnumerable<TbUniversidade>> GetUniversidadesAsync();
        Task<IEnumerable<TbAreasMedica>> GetAreasMedicasAsync();
        Task<IEnumerable<TbCentrosMedico>> GetCentrosMedicosAsync();
        Task<IEnumerable<TbTurnosMedico>> GetTurnosMedicosAsync();

        //Métodos de historial clínico
        //Task<IEnumerable<TbBarrio>> GetBarriosAsync();
    }
}
