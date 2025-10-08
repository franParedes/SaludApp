using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.DTOs.UtilitiesDTO
{
    public class BarriosDTO
    {
        public int IdBarrio { get; set; }
        public string Barrio { get; set; } = null!;
        public int MunicipioAlQuePertenece {  get; set; }
    }
}
