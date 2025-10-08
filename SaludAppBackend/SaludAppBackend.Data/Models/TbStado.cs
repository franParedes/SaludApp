using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbStado
{
    public int IdEstado { get; set; }

    public string Estado { get; set; } = null!;

    public int? TipoEstado { get; set; }

    public virtual TbTipoEstado? TipoEstadoNavigation { get; set; }
}
