using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbDireccione
{
    public int IdDireccion { get; set; }

    public int IdUsuario { get; set; }

    public int? Departamento { get; set; }

    public int? Municipio { get; set; }

    public int? Barrio { get; set; }

    public string Direccion { get; set; } = null!;

    public virtual TbBarrio? BarrioNavigation { get; set; }

    public virtual TbDepartamento? DepartamentoNavigation { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;

    public virtual TbMunicipio? MunicipioNavigation { get; set; }
}
