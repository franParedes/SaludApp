using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbEspecialidade
{
    public int IdEspecialidad { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<TbCitasMedica> TbCitasMedicas { get; set; } = new List<TbCitasMedica>();

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();
}
