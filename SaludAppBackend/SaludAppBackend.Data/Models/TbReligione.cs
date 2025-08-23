using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbReligione
{
    public int IdReligion { get; set; }

    public string? Religion { get; set; }

    public virtual ICollection<TbPaciente> TbPacientes { get; set; } = new List<TbPaciente>();
}
