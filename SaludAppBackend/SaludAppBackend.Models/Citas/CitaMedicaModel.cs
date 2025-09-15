using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Citas
{
    public class CitaMedicaModel : CitaModel
    {
        public int MedicoId { get; set; }
        public int Especialidad { get; set; }
    }
}
