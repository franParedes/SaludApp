using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
