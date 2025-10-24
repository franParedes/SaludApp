using Riok.Mapperly.Abstractions;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Services.DTOs.UsuariosDTO;
using SaludAppBackend.Services.DTOs.UtilitiesDTO;

namespace SaludAppBackend.Services.Mapper
{
    [Mapper(IgnoreObsoleteMembersStrategy = IgnoreObsoleteMembersStrategy.Source, RequiredMappingStrategy = RequiredMappingStrategy.None)]
    public partial class UsuariosMapper
    {
        public partial IEnumerable<UsuarioPorTipoDTO> UsuariosPorTipoToUsuariosPorTipoDTO(IEnumerable<TbUsuario> usuario);
    }
}
