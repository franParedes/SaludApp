using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbCitasMedica
{
    public int IdCita { get; set; }

    public int PacienteId { get; set; }

    public int MedicoId { get; set; }

    public int? Especialidad { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaCita { get; set; }

    public string Estado { get; set; } = null!;

    public string? MotivoRechazo { get; set; }

    public string? MotivoCita { get; set; }

    public virtual TbEspecialidade? EspecialidadNavigation { get; set; }

    public virtual TbMedico Medico { get; set; } = null!;

    public virtual TbPaciente Paciente { get; set; } = null!;
}
