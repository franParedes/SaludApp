using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbEnfermedadesInfectoContagiosa
{
    public int IdEnfermedad { get; set; }

    public string Enfermedad { get; set; } = null!;
}
