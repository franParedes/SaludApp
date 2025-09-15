using SaludAppBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Medicos
{
    public interface IMedicoRepository
    {
        Task AddMedicoAsync(TbMedico medico);
    }
}
