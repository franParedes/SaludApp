using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbStado
{
    public int IdEstado { get; set; }

    public string Estado { get; set; } = null!;

    public int? TipoEstado { get; set; }

    public virtual ICollection<TbCita> TbCita { get; set; } = new List<TbCita>();

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();

    public virtual TbTipoEstado? TipoEstadoNavigation { get; set; }
}
