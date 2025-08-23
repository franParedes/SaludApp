using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbDepartamento
{
    public int IdDepartamento { get; set; }

    public string? Departamento { get; set; }

    public virtual ICollection<TbCentrosMedico> TbCentrosMedicos { get; set; } = new List<TbCentrosMedico>();

    public virtual ICollection<TbDireccione> TbDirecciones { get; set; } = new List<TbDireccione>();
}
