using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.DTOs;

namespace SaludAppBackend.Data.Repositories.Utilities
{
    public interface IUtilitiesRepository
    {
        Task<IEnumerable<TbTipoUsuario>> GetTiposDeUsuarioAsync();

        //Métodos de pacientes
        Task<IEnumerable<TbGenero>> GetGenerosAsync();
        Task<IEnumerable<TbProvTelefonico>> GetProveedoresTelefonicoAsync();
        Task<IEnumerable<TbDepartamento>> GetDepartamentosAsync();
        Task<IEnumerable<TbMunicipio>> GetMunicipiosPorDepartamentoAsync(int departamento);
        Task<IEnumerable<TbBarrio>> GetBarriosPorMunicipioAsync(int municipio);
        Task<IEnumerable<TbReligione>> GetReligionesAsync();
        Task<IEnumerable<TbOcupacione>> GetOcupacionesPacientesAsync();

        //Métodos de médicos
        Task<IEnumerable<TbEspecialidade>> GetEspecialidadesMedicasAsync();
        Task<IEnumerable<TbUniversidade>> GetUniversidadesAsync();
        Task<IEnumerable<TbAreasMedica>> GetAreasMedicasAsync();
        Task<IEnumerable<TbCentrosMedico>> GetCentrosMedicosAsync();
        Task<IEnumerable<TbTurnosMedico>> GetTurnosMedicosAsync();

        //Métodos para citas
        Task<IEnumerable<TbTiposCita>> GetTipoDeCitasAsync();

        //Métodos de historial clínico
        //Task<IEnumerable<TbBarrio>> GetBarriosAsync();
    }
}
