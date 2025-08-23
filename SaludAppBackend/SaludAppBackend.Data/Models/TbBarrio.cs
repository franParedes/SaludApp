using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbBarrio
{
    public int IdBarrio { get; set; }

    public string? Barrio { get; set; }

    public virtual ICollection<TbDireccione> TbDirecciones { get; set; } = new List<TbDireccione>();
}
