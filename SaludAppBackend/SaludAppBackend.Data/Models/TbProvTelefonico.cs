using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbProvTelefonico
{
    public int IdProvTel { get; set; }

    public string? Proveedor { get; set; }

    public virtual ICollection<TbTelefono> TbTelefonos { get; set; } = new List<TbTelefono>();
}
