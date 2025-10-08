using Riok.Mapperly.Abstractions;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Services.DTOs.UtilitiesDTO;

namespace SaludAppBackend.Services.Mapper
{
    [Mapper(IgnoreObsoleteMembersStrategy = IgnoreObsoleteMembersStrategy.Source, RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class UtilitiesMapper
    {
        //Mappers de usuarios
        public partial IEnumerable<TiposUsuarioDTO> TipoUsuarioToTiposUsuarioDTO(IEnumerable<TbTipoUsuario> tiposUsuario);
        public partial IEnumerable<GenerosDTO> GenerosToGenerosDTO(IEnumerable<TbGenero> generos);
        public partial IEnumerable<ProvTelefonicosDTO> ProvTelefonicosToProvTelefonicosDTO(IEnumerable<TbProvTelefonico> provTelefonicos);
        public partial IEnumerable<DepartamentosDTO> DepartamentosToDepartamentosDTO(IEnumerable<TbDepartamento> departamentos);
        public partial IEnumerable<MunicipiosDTO> MunicipiosToMunicipiosDTO(IEnumerable<TbMunicipio> municipios);
        public partial IEnumerable<BarriosDTO> BarriosToBarriosDTO(IEnumerable<TbBarrio> barrios);
        public partial IEnumerable<ReligionesDTO> ReligionesToReligionesDTO(IEnumerable<TbReligione> religiones);
        public partial IEnumerable<OcupacionesDTO> OcupacionesToOcupacionesDTO(IEnumerable<TbOcupacione> ocupaciones);

        ////Mappers de medicos
        public partial IEnumerable<EspecialidadesDTO> EspecialidadesToEspecialidadesDTO(IEnumerable<TbEspecialidade> especialidades);
        public partial IEnumerable<UniversidadesDTO> UniversidadesToUniversidadesDTO(IEnumerable<TbUniversidade> universidades);
        public partial IEnumerable<AreasMedicasDTO> AreasMedicasToAreasMedicasDTO(IEnumerable<TbAreasMedica> areasMedicas);
        public partial IEnumerable<CentrosMedicosDTO> CentrosMedicosToCentrosMedicosDTO(IEnumerable<TbCentrosMedico> centrosMedicos);
        public partial IEnumerable<TurnosMedicosDTO> TurnosMedicosToTurnosMedicosDTO(IEnumerable<TbTurnosMedico> turnosMedicos);
        public partial IEnumerable<TiposCitasDTO> TiposCitasToTiposCitasDTO(IEnumerable<TbTiposCita> tiposCitas);

        //Se usa así:
        //private readonly UtilitiesMapper _mapper = new();
        //_mapper.DepartamentoToDepartamentoDTO(departamentosList);
    }
}
