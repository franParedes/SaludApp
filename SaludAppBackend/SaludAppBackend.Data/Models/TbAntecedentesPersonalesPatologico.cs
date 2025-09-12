using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbAntecedentesPersonalesPatologico
{
    public int IdAntecendentePersonalP { get; set; }

    public string? EnfInfectoContagiosas { get; set; }

    public string? EnfCronicas { get; set; }

    public string? CirugiasPreviasRealizadas { get; set; }
}
