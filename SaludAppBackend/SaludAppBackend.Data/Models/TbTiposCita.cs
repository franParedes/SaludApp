using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTiposCita
{
    public int IdTipoCita { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<TbCita> TbCita { get; set; } = new List<TbCita>();
}
