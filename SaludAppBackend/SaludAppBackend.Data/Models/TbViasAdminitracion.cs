using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbViasAdminitracion
{
    public int IdViaAdm { get; set; }

    public string ViaAdm { get; set; } = null!;

    public virtual ICollection<TbMedicamentosRecetado> TbMedicamentosRecetados { get; set; } = new List<TbMedicamentosRecetado>();
}
