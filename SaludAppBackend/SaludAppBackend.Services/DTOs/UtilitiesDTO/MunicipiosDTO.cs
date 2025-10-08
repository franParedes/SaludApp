using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.DTOs.UtilitiesDTO {
    public class MunicipiosDTO
    {
        public int IdMunicipio {  get; set; }
        public string Municipio { get; set; } = null!;
        public int DepartamentoAlQuePertenece {  get; set; }
    }
}
