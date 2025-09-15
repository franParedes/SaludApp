using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbResumenCitaMedica
{
    public int IdResumenCita { get; set; }

    public int IdCita { get; set; }

    public string? PresionArterial { get; set; }

    public float? TemperaturaCorporal { get; set; }

    public int? FrecuenciaCardiaca { get; set; }

    public int? FrecuenciaRespiratoria { get; set; }

    public string? Diagnostico { get; set; }

    public virtual TbCita IdCitaNavigation { get; set; } = null!;

    public virtual ICollection<TbMedicamentosRecetado> TbMedicamentosRecetados { get; set; } = new List<TbMedicamentosRecetado>();
}
