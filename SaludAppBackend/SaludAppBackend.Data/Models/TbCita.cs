using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbCita
{
    public int IdCita { get; set; }

    public int PacienteId { get; set; }

    public int? Lugar { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaCita { get; set; }

    public int? Estado { get; set; }

    public string? MotivoCita { get; set; }

    public string? MotivoRechazo { get; set; }

    public int? TipoCita { get; set; }

    public virtual TbStado? EstadoNavigation { get; set; }

    public virtual TbCentrosMedico? LugarNavigation { get; set; }

    public virtual TbPaciente Paciente { get; set; } = null!;

    public virtual ICollection<TbCitasLaboratorio> TbCitasLaboratorios { get; set; } = new List<TbCitasLaboratorio>();

    public virtual ICollection<TbCitasMedica> TbCitasMedicas { get; set; } = new List<TbCitasMedica>();

    public virtual ICollection<TbResumenCitaMedica> TbResumenCitaMedicas { get; set; } = new List<TbResumenCitaMedica>();

    public virtual TbTiposCita? TipoCitaNavigation { get; set; }
}
