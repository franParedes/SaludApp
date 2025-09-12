using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbAntecedentesPersonalesNoPatologico
{
    public int IdAntecedentePerNop { get; set; }

    public bool InmunizacionCompleta { get; set; }

    public int HorasSuenyo { get; set; }

    public int HorasLaborales { get; set; }

    public string? TipoActFisica { get; set; }

    public TimeOnly? HoraActFisica { get; set; }

    public string? Alimentacion { get; set; }

    public int? Fumador { get; set; }

    public virtual ICollection<TbHistorialMedico> TbHistorialMedicos { get; set; } = new List<TbHistorialMedico>();
}
