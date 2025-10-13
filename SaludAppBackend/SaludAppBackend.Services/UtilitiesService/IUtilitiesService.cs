using SaludAppBackend.Services.DTOs.UtilitiesDTO;

namespace SaludAppBackend.Services.UtilitiesService
{
    public interface IUtilitiesService
    {
        Task<IEnumerable<TiposUsuarioDTO>> GetTiposDeUsuario();
        
        //Métodos de pacientes
        Task<IEnumerable<GenerosDTO>> GetGenerosAsync();
        Task<IEnumerable<ProvTelefonicosDTO>> GetProveedoresTelefonicoAsync();
        Task<IEnumerable<DepartamentosDTO>> GetDepartamentosAsync();
        Task<IEnumerable<MunicipiosDTO>> GetMunicipiosPorDepartamentoAsync(int departamento);
        Task<IEnumerable<BarriosDTO>> GetBarriosPorMunicipioAsync(int municipio);
        Task<IEnumerable<ReligionesDTO>> GetReligionesAsync();
        Task<IEnumerable<EstadoCivilDTO>> GetEstadosCivilesAsync();
        Task<IEnumerable<EscolaridadDTO>> GetEscolaridadesAsync();
        Task<IEnumerable<OcupacionesDTO>> GetOcupacionesPacientesAsync();

        //Métodos de médicos
        Task<IEnumerable<EspecialidadesDTO>> GetEspecialidadesMedicasAsync();
        Task<IEnumerable<UniversidadesDTO>> GetUniversidadesAsync();
        Task<IEnumerable<AreasMedicasDTO>> GetAreasMedicasAsync();
        Task<IEnumerable<CentrosMedicosDTO>> GetCentrosMedicosAsync();
        Task<IEnumerable<TurnosMedicosDTO>> GetTurnosMedicosAsync();

        //Métodos para citas
        Task<IEnumerable<TiposCitasDTO>> GetTipoDeCitasAsync();
    }
}
