using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbRecepcionista
{
    public int IdRecep { get; set; }

    public int IdUsuario { get; set; }

    public int? CentroActual { get; set; }

    public int? TurnoActual { get; set; }

    public virtual TbCentrosMedico? CentroActualNavigation { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;

    public virtual TbTurnosMedico? TurnoActualNavigation { get; set; }
}
