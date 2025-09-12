using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.UtilitiesService
{
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UtilitiesService> _logger;

        public UtilitiesService(IUnitOfWork unitOfWork, ILogger<UtilitiesService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<TbAreasMedica>> GetAreasMedicasAsync()
            => await _unitOfWork.Utilities.GetAreasMedicasAsync();

        public async Task<IEnumerable<TbBarrio>> GetBarriosAsync()
            => await _unitOfWork.Utilities.GetBarriosAsync();

        public async Task<IEnumerable<TbCentrosMedico>> GetCentrosMedicosAsync()
            => await _unitOfWork.Utilities.GetCentrosMedicosAsync();

        public async Task<IEnumerable<TbDepartamento>> GetDepartamentosAsync()
            => await _unitOfWork.Utilities.GetDepartamentosAsync();

        public async Task<IEnumerable<TbEspecialidade>> GetEspecialidadesMedicasAsync()
            => await _unitOfWork.Utilities.GetEspecialidadesMedicasAsync();

        public async Task<IEnumerable<TbGenero>> GetGenerosAsync()
            => await _unitOfWork.Utilities.GetGenerosAsync();

        public async Task<IEnumerable<TbMunicipio>> GetMunicipiosAsync()
            => await _unitOfWork.Utilities.GetMunicipiosAsync();

        public async Task<IEnumerable<TbOcupacione>> GetOcupacionesPacientesAsync()
            => await _unitOfWork.Utilities.GetOcupacionesPacientesAsync();

        public async Task<IEnumerable<TbProvTelefonico>> GetProveedoresTelefonicoAsync()
            => await _unitOfWork.Utilities.GetProveedoresTelefonicoAsync();

        public async Task<IEnumerable<TbReligione>> GetReligionesAsync()
            => await _unitOfWork.Utilities.GetReligionesAsync();

        public async Task<IEnumerable<TbTipoUsuario>> GetTiposDeUsuario()
            => await _unitOfWork.Utilities.GetTiposDeUsuarioAsync();

        public async Task<IEnumerable<TbTurnosMedico>> GetTurnosMedicosAsync()
            => await _unitOfWork.Utilities.GetTurnosMedicosAsync();

        public async Task<IEnumerable<TbUniversidade>> GetUniversidadesAsync()
            => await _unitOfWork.Utilities.GetUniversidadesAsync();
    }
}
