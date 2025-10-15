using SaludAppBackend.Models.Citas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.CitasService
{
    public interface ICitaService
    {
        Task<int> CrearNuevaCitaMedicaAsync(CitaMedicaModel citaMedica);
        Task<int> CrearNuevaCitaDeLaboratorioAsync(CitaLaboratorioModel citaLaboratorio);
        Task<bool> CambiarEstadoCita(int Estado, int idCita);
        Task<bool> AprobarCita(int idCita, DateTime fechaCita);
        Task<bool> RechazarCita(int idCita, string motivoRechazo);
        Task<bool> EliminarCitaMedica(int idCitaMedica);
        Task<bool> EliminarCitaLab(int idCitaLab);
        Task<IEnumerable<CitaPendienteModel>> ObtenerListaDeCitasPendientes();
        Task<DetalleCitaMedicaModel> ObtenerDetalleDeCitaMedica(int idCita);
        Task<DetalleCitaLaboratorioModel> ObtenerDetalleDeCitaLaboratorio(int idCita);
    }
}
