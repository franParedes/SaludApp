using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbPasswd
{
    public int IdPasswd { get; set; }

    public int IdUsuario { get; set; }

    public string? HashPasswd { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}
