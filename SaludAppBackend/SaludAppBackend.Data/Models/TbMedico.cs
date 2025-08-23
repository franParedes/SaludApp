using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbMedico
{
    public int IdMedico { get; set; }

    public int IdUsuario { get; set; }

    public string CodSanitario { get; set; } = null!;

    public int? Especialidad { get; set; }

    public int? EgresadoDe { get; set; }

    public DateOnly EgresadoEl { get; set; }

    public int ExperienciaAnyos { get; set; }

    public int? AreaActual { get; set; }

    public int? CentroActual { get; set; }

    public int? TurnoActual { get; set; }

    public virtual TbAreasMedica? AreaActualNavigation { get; set; }

    public virtual TbCentrosMedico? CentroActualNavigation { get; set; }

    public virtual TbUniversidade? EgresadoDeNavigation { get; set; }

    public virtual TbEspecialidade? EspecialidadNavigation { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;

    public virtual TbTurnosMedico? TurnoActualNavigation { get; set; }
}
