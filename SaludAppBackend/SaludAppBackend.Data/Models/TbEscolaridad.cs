using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbEscolaridad
{
    public int IdEscolaridad { get; set; }

    public string Escolaridad { get; set; } = null!;

    public virtual ICollection<TbPaciente> TbPacientes { get; set; } = new List<TbPaciente>();
}
