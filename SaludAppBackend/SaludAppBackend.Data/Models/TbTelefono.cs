using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTelefono
{
    public int IdTelefono { get; set; }

    public int Telefono { get; set; }

    public int IdUsuario { get; set; }

    public int? Compania { get; set; }

    public virtual TbProvTelefonico? CompaniaNavigation { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}
