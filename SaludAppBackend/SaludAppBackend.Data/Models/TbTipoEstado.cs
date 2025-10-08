using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTipoEstado
{
    public int IdTipo { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<TbStado> TbStados { get; set; } = new List<TbStado>();
}
