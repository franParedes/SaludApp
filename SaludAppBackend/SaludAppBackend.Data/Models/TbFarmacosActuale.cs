using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbFarmacosActuale
{
    public int IdFarmaco { get; set; }

    public int PacienteId { get; set; }

    public string NombreFarmaco { get; set; } = null!;

    public string PosologiaFarmaco { get; set; } = null!;

    public bool? EstaEnUso { get; set; }

    public virtual TbPaciente Paciente { get; set; } = null!;
}
