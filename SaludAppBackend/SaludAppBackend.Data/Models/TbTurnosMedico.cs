using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbTurnosMedico
{
    public int IdTurno { get; set; }

    public string? Turno { get; set; }

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();

    public virtual ICollection<TbRecepcionista> TbRecepcionista { get; set; } = new List<TbRecepcionista>();

    public virtual ICollection<TbUsuarioRegistro> TbUsuarioRegistros { get; set; } = new List<TbUsuarioRegistro>();
}
