using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Citas
{
    public class DetalleCitaLaboratorioModel
    {
        public int IdCita { get; set; }
        public int IdPendiente { get; set; }
        public string CentroMedico { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estado { get; set; } = null!;
        public string MotivoCita { get; set; } = null!;
        public string MotivoRechazo { get; set; } = null!;
        public string ExamenesRealizar {  get; set; } = null!;
    }
}
