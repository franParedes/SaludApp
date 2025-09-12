using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbDrogasLegale
{
    public int IdDrogasLegales { get; set; }

    public string? Tipo { get; set; }

    public int CantidadUnidades { get; set; }

    public int Freuencia { get; set; }

    public int EdadInicio { get; set; }

    public int? EdadAbandono { get; set; }

    public int? DuracionAnyos { get; set; }

    public virtual ICollection<TbHistorialMedico> TbHistorialMedicos { get; set; } = new List<TbHistorialMedico>();
}
