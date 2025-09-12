using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbEnfermedadesCronica
{
    public int IdEnfermedadCronica { get; set; }

    public string Enfermedad { get; set; } = null!;
}
