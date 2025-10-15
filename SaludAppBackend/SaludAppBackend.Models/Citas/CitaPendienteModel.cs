using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Citas
{
    public class CitaPendienteModel
    {
        public int IdCita { get; set; }
        public int IdPendiente { get; set; }
        public string CentroMedico { get; set; } = null!;
        public string TipoDeCita { get; set; } = null!;
    }
}
