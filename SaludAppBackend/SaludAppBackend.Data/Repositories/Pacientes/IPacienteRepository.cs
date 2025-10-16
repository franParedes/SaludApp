using SaludAppBackend.Data.Models;
using SaludAppBackend.Models.Usuarios;

namespace SaludAppBackend.Data.Repositories.Pacientes
{
    public interface IPacienteRepository
    {
        Task AddPacienteAsync(TbPaciente paciente);
        Task<int> BuscarPacientePorIdAsync(int idPaciente);
        Task<InformacionGeneralPacienteModel?> ObtenerInformacionGeneralPaciente(int idUsuario);
    }
}
