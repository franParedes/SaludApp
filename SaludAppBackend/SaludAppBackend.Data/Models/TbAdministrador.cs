using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbAdministrador
{
    public int IdAdmin { get; set; }

    public int IdUsuario { get; set; }

    public int? CentroActual { get; set; }

    public virtual TbCentrosMedico? CentroActualNavigation { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}
