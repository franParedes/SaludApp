using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTurnosMedico
{
    public int IdTurno { get; set; }

    public string? Turno { get; set; }

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();
}
