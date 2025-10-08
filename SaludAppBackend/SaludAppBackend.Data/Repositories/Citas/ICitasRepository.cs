using SaludAppBackend.Data.Models;

namespace SaludAppBackend.Data.Repositories.Citas
{
    public interface ICitasRepository
    {
        Task AddCita(TbCita cita);
        Task AddCitaMedica(TbCitasMedica citaMedica);
        Task AddCitaLaboratorio(TbCitasLaboratorio citaLab);
        void CambiarEstadoCita(int Estado, int idCita);
        void AprobarCita(int idCita, DateTime fechaCita);
        void RechazarCita(int idCita, string motivoRechazo);
        void EliminarCitaMedica(int idCitaMedica);
        void EliminarCitaLab(int idCitaLab);
    }
}
