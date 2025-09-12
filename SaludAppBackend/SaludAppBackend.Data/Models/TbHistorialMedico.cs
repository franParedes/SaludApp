using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbHistorialMedico
{
    public int IdHistorial { get; set; }

    public int IdPaciente { get; set; }

    public int IdDireccionHabitual { get; set; }

    public int? CantidadCitasHechas { get; set; }

    public int? AntecedFamPatologicos { get; set; }

    public int? AntecedPerNoPatologicos { get; set; }

    public int? EsFumador { get; set; }

    public int? EsAlcoholico { get; set; }

    public int? DrogasLegales { get; set; }

    public string? OtrosHabitos { get; set; }

    public virtual TbAntecedentesFamiliaresPatologico? AntecedFamPatologicosNavigation { get; set; }

    public virtual TbAntecedentesPersonalesNoPatologico? AntecedPerNoPatologicosNavigation { get; set; }

    public virtual TbDrogasLegale? DrogasLegalesNavigation { get; set; }

    public virtual TbEsAlcoholico? EsAlcoholicoNavigation { get; set; }

    public virtual TbEsFumador? EsFumadorNavigation { get; set; }

    public virtual TbPaciente IdPacienteNavigation { get; set; } = null!;
}
