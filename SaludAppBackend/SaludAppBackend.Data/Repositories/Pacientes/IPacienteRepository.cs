using SaludAppBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Pacientes
{
    public interface IPacienteRepository
    {
        Task AddPacienteAsync(TbPaciente paciente);
    }
}
