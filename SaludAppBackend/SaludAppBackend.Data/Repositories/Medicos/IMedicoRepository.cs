using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Medicos
{
    public interface IMedicoRepository
    {
        Task AddMedicoAsync(TbMedico medico);
        Task<int> BuscarMedicoPorIdAsync(int idMedico);
        Task<int> AsignarMedicoAcita(int idEspecialidad);
    }
}
