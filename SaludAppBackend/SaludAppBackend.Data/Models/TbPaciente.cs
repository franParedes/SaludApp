using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbPaciente
{
    public int IdPaciente { get; set; }

    public int IdUsuario { get; set; }

    public string? NumeroInss { get; set; }

    public int? Ocupacion { get; set; }

    public string Escolaridad { get; set; } = null!;

    public int? Religion { get; set; }

    public int Edad { get; set; }

    public string EstadoCivil { get; set; } = null!;

    public int CantidadHermanos { get; set; }

    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;

    public virtual TbOcupacione? OcupacionNavigation { get; set; }

    public virtual TbReligione? ReligionNavigation { get; set; }

    public virtual ICollection<TbCitasMedica> TbCitasMedicas { get; set; } = new List<TbCitasMedica>();

    public virtual ICollection<TbFarmacosActuale> TbFarmacosActuales { get; set; } = new List<TbFarmacosActuale>();

    public virtual ICollection<TbHistorialMedico> TbHistorialMedicos { get; set; } = new List<TbHistorialMedico>();

    public virtual ICollection<TbHospitalizacione> TbHospitalizaciones { get; set; } = new List<TbHospitalizacione>();
}
