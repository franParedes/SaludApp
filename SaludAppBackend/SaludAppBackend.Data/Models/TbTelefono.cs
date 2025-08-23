using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTelefono
{
    public int IdTelefono { get; set; }

    public int? Telefono { get; set; }

    public int Persona { get; set; }

    public int? Compania { get; set; }

    public bool? IsUserapp { get; set; }

    public virtual TbProvTelefonico? CompaniaNavigation { get; set; }
}
