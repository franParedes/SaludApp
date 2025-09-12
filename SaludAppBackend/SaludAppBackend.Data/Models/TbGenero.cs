using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbGenero
{
    public int IdGenero { get; set; }

    public string Genero { get; set; } = null!;

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
