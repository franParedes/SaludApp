using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbMunicipio
{
    public int IdMunicipio { get; set; }

    public string? Municipio { get; set; }

    public virtual ICollection<TbCentrosMedico> TbCentrosMedicos { get; set; } = new List<TbCentrosMedico>();

    public virtual ICollection<TbDireccione> TbDirecciones { get; set; } = new List<TbDireccione>();
}
