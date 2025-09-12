using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbHospitalizacione
{
    public int IdHospitalizacion { get; set; }

    public int PacienteId { get; set; }

    public DateTime Fecha { get; set; }

    public string? Causa { get; set; }

    public virtual TbPaciente Paciente { get; set; } = null!;
}
