using SaludAppBackend.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.PacienteService
{
    public interface IPacienteService
    {
        Task<int> CrearNuevoPacienteAsync(PacienteModel paciente);
        Task<InformacionGeneralPacienteModel?> ObtenerInformacionGeneralPaciente(int idUsuario);
    }
}
