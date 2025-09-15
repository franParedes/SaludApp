using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbCitasLaboratorio
{
    public int IdCitaLab { get; set; }

    public int IdCita { get; set; }

    public string? ExamenesRealizar { get; set; }

    public virtual TbCita IdCitaNavigation { get; set; } = null!;

    public virtual ICollection<TbArchivosCitasLab> TbArchivosCitasLabs { get; set; } = new List<TbArchivosCitasLab>();
}
