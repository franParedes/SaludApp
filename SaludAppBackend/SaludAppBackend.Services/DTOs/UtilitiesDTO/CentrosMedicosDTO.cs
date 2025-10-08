using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.DTOs.UtilitiesDTO
{
    public class CentrosMedicosDTO
    {
        public int IdCentro { get; set; }
        public string? Centro { get; set; }

        public int? Departamento { get; set; }

        public int? Municipio { get; set; }
    }
}
