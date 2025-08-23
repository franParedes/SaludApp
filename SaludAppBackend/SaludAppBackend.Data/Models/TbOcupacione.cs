using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbOcupacione
{
    public int IdOcupacion { get; set; }

    public string? Ocupacion { get; set; }

    public virtual ICollection<TbPaciente> TbPacientes { get; set; } = new List<TbPaciente>();
}
