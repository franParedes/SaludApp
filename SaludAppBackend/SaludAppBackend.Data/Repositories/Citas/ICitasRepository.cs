using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Citas
{
    public interface ICitasRepository
    {
        Task AddCitaMedica();
        Task AddCitaLaboratorio();
    }
}
