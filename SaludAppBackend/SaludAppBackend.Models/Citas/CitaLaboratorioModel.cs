using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Citas
{
    public class CitaLaboratorioModel : CitaModel
    {
        public CitaLaboratorioModel() 
        {
            ExamanesRealizar = [];
        }
        public List<string> ExamanesRealizar { get; set; }
    }
}
