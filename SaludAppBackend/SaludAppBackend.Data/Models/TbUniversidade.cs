using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbUniversidade
{
    public int IdUniversidad { get; set; }

    public string? Universidad { get; set; }

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();
}
