using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.UtilitiesService
{
    public interface IUtilitiesService
    {
        Task<IEnumerable<TbTipoUsuario>> GetTiposDeUsuario();
        
        //Métodos de pacientes
        Task<IEnumerable<TbGenero>> GetGenerosAsync();
        Task<IEnumerable<TbProvTelefonico>> GetProveedoresTelefonicoAsync();
        Task<IEnumerable<TbDepartamento>> GetDepartamentosAsync();
        Task<IEnumerable<MunicipiosDTO>> GetMunicipiosPorDepartamentoAsync(int departamento);
        Task<IEnumerable<BarriosDTO>> GetBarriosPorMunicipioAsync(int municipio);
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
    }
}
