using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Citas
{
    public class DetalleCitaMedicaModel
    {
        public int IdCita { get; set; }
        public int IdPendiente { get; set; }
        public string? CentroMedico { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaCita { get; set; }
        public string? Estado { get; set; }
        public string? MotivoCita { get; set; }
        public string? MotivoRechazo { get; set; }
        public int MedicoId { get; set; }
        public string? Medico { get; set; }
        public string? Especialidad { get; set; }
    }
}
