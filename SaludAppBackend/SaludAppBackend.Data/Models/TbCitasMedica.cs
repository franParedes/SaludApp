using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbCitasMedica
{
    public int IdCitaMedica { get; set; }

    public int IdCita { get; set; }

    public int MedicoId { get; set; }

    public int? Especialidad { get; set; }

    public virtual TbEspecialidade? EspecialidadNavigation { get; set; }

    public virtual TbCita IdCitaNavigation { get; set; } = null!;

    public virtual TbMedico Medico { get; set; } = null!;

    public virtual ICollection<TbArchivosCitasMedica> TbArchivosCitasMedicas { get; set; } = new List<TbArchivosCitasMedica>();
}
