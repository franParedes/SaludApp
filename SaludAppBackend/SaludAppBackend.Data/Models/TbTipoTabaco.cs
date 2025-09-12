using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTipoTabaco
{
    public int IdTipoTabaco { get; set; }

    public string Tipo { get; set; } = null!;
}
