using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbUsuario
{
    public int IdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string Correo { get; set; } = null!;

    public int? Genero { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public int? TipoUsuario { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public DateOnly FechaActualizacion { get; set; }

    public bool? Activo { get; set; }

    public virtual TbGenero? GeneroNavigation { get; set; }

    public virtual ICollection<TbDireccione> TbDirecciones { get; set; } = new List<TbDireccione>();

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();

    public virtual TbPaciente? TbPaciente { get; set; }

    public virtual TbPasswd? TbPasswd { get; set; }

    public virtual ICollection<TbTelefono> TbTelefonos { get; set; } = new List<TbTelefono>();

    public virtual TbTipoUsuario? TipoUsuarioNavigation { get; set; }
}
