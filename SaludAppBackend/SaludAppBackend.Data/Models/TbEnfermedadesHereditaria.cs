using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbEnfermedadesHereditaria
{
    public int IdEnfermedad { get; set; }

    public string Enfermedad { get; set; } = null!;
}
