using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbAreasMedica
{
    public int IdArea { get; set; }

    public string? Area { get; set; }

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();
}
