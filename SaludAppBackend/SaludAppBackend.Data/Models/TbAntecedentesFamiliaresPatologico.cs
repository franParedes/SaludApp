using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbAntecedentesFamiliaresPatologico
{
    public int IdAntecendenteFamp { get; set; }

    public string? EnfInfectoContagiosas { get; set; }

    public string? EnfHereditarias { get; set; }

    public virtual ICollection<TbHistorialMedico> TbHistorialMedicos { get; set; } = new List<TbHistorialMedico>();
}
