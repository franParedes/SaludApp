using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Services.DTOs.UtilitiesDTO;
using SaludAppBackend.Services.Mapper;

namespace SaludAppBackend.Services.UtilitiesService
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UtilitiesService> _logger;
        private readonly UtilitiesMapper _mapper = new();

        public UtilitiesService(IUnitOfWork unitOfWork, ILogger<UtilitiesService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<AreasMedicasDTO>> GetAreasMedicasAsync()
        {
            var areasMedicasList = await _unitOfWork.Utilities.GetAreasMedicasAsync();
            return _mapper.AreasMedicasToAreasMedicasDTO(areasMedicasList);
        }

        public async Task<IEnumerable<BarriosDTO>> GetBarriosPorMunicipioAsync(int municipio)
        {
            var barriosList = await _unitOfWork.Utilities.GetBarriosPorMunicipioAsync(municipio);
            return _mapper.BarriosToBarriosDTO(barriosList);
        }

        public async Task<IEnumerable<CentrosMedicosDTO>> GetCentrosMedicosAsync()
        {
            var centrosMedicosList = await _unitOfWork.Utilities.GetCentrosMedicosAsync();
            return _mapper.CentrosMedicosToCentrosMedicosDTO(centrosMedicosList);
        }

        public async Task<IEnumerable<DepartamentosDTO>> GetDepartamentosAsync()
        {
            var departamentosList = await _unitOfWork.Utilities.GetDepartamentosAsync();
            return _mapper.DepartamentosToDepartamentosDTO(departamentosList);
        }

        public async Task<IEnumerable<EspecialidadesDTO>> GetEspecialidadesMedicasAsync()
        {
            var especialidadesMedicasList = await _unitOfWork.Utilities.GetEspecialidadesMedicasAsync();
            return _mapper.EspecialidadesToEspecialidadesDTO(especialidadesMedicasList);
        }

        public async Task<IEnumerable<GenerosDTO>> GetGenerosAsync()
        {
            var generosList = await _unitOfWork.Utilities.GetGenerosAsync();
            return _mapper.GenerosToGenerosDTO(generosList);
        }

        public async Task<IEnumerable<MunicipiosDTO>> GetMunicipiosPorDepartamentoAsync(int departamento)
        {
            var municipiosList = await _unitOfWork.Utilities.GetMunicipiosPorDepartamentoAsync(departamento);
            return _mapper.MunicipiosToMunicipiosDTO(municipiosList);
        }

        public async Task<IEnumerable<OcupacionesDTO>> GetOcupacionesPacientesAsync()
        {
            var ocupacionesList = await _unitOfWork.Utilities.GetOcupacionesPacientesAsync();
            return _mapper.OcupacionesToOcupacionesDTO(ocupacionesList);
        }

        public async Task<IEnumerable<ProvTelefonicosDTO>> GetProveedoresTelefonicoAsync()
        {
            var provTelList = await _unitOfWork.Utilities.GetProveedoresTelefonicoAsync();
            return _mapper.ProvTelefonicosToProvTelefonicosDTO(provTelList);
        }

        public async Task<IEnumerable<ReligionesDTO>> GetReligionesAsync()
        {
            var religionesList = await _unitOfWork.Utilities.GetReligionesAsync();
            return _mapper.ReligionesToReligionesDTO(religionesList);
        }

        public async Task<IEnumerable<EstadoCivilDTO>> GetEstadosCivilesAsync()
        {
            var estadosCivilesList = await _unitOfWork.Utilities.GetEstadosCivilesAsync();
            return _mapper.EstadoCivilToEstadoCivilDTO(estadosCivilesList);
        }

        public async Task<IEnumerable<EscolaridadDTO>> GetEscolaridadesAsync()
        {
            var escolaridadList = await _unitOfWork.Utilities.GetEscolaridadesAsync();
            return _mapper.EscolaridadToEscolaridadDTO(escolaridadList);
        }

        public async Task<IEnumerable<TiposCitasDTO>> GetTipoDeCitasAsync()
        {
            var tipoCitasList = await _unitOfWork.Utilities.GetTipoDeCitasAsync();
            return _mapper.TiposCitasToTiposCitasDTO(tipoCitasList);
        }

        public async Task<IEnumerable<TiposUsuarioDTO>> GetTiposDeUsuario()
        {
            var tipoUsuarioList = await _unitOfWork.Utilities.GetTiposDeUsuarioAsync();
            return _mapper.TipoUsuarioToTiposUsuarioDTO(tipoUsuarioList);
        }

        public async Task<IEnumerable<TurnosMedicosDTO>> GetTurnosMedicosAsync()
        {
            var turnosList = await _unitOfWork.Utilities.GetTurnosMedicosAsync();
            return _mapper.TurnosMedicosToTurnosMedicosDTO(turnosList);
        }

        public async Task<IEnumerable<UniversidadesDTO>> GetUniversidadesAsync()
        {
            var universidadesList = await _unitOfWork.Utilities.GetUniversidadesAsync();
            return _mapper.UniversidadesToUniversidadesDTO(universidadesList);
        }
    }
}
