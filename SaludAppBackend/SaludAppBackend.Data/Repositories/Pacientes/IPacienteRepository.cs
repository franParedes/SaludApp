using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Pacientes
{
    public interface IPacienteRepository
    {
        Task AddPacienteAsync(TbPaciente paciente);
        Task<int> BuscarPacientePorIdAsync(int idPaciente);
    }
}
