using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbEstadoCivil
{
    public int IdEstadoCivil { get; set; }

    public string EstadoCivil { get; set; } = null!;

    public virtual ICollection<TbPaciente> TbPacientes { get; set; } = new List<TbPaciente>();
}
