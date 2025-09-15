using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbMedicamentosRecetado
{
    public int IdMedicamento { get; set; }

    public int IdResumenCita { get; set; }

    public string Medicamento { get; set; } = null!;

    public string? Dosis { get; set; }

    public int? FrecuenciaHoras { get; set; }

    public int? ViaAdministracion { get; set; }

    public int? DuracionDias { get; set; }

    public virtual TbResumenCitaMedica IdResumenCitaNavigation { get; set; } = null!;

    public virtual TbViasAdminitracion? ViaAdministracionNavigation { get; set; }
}
