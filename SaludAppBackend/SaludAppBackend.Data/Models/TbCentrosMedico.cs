using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbCentrosMedico
{
    public int IdCentro { get; set; }

    public string? Centro { get; set; }

    public int? Departamento { get; set; }

    public int? Municipio { get; set; }

    public virtual TbDepartamento? DepartamentoNavigation { get; set; }

    public virtual TbMunicipio? MunicipioNavigation { get; set; }

    public virtual ICollection<TbAdministrador> TbAdministradors { get; set; } = new List<TbAdministrador>();

    public virtual ICollection<TbCita> TbCita { get; set; } = new List<TbCita>();

    public virtual ICollection<TbMedico> TbMedicos { get; set; } = new List<TbMedico>();

    public virtual ICollection<TbRecepcionista> TbRecepcionista { get; set; } = new List<TbRecepcionista>();

    public virtual ICollection<TbUsuarioRegistro> TbUsuarioRegistros { get; set; } = new List<TbUsuarioRegistro>();
}
