using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbArchivo
{
    public int ArchivoId { get; set; }

    public string NombreArchivo { get; set; } = null!;

    public string TipoArchivo { get; set; } = null!;

    public string TipoMime { get; set; } = null!;

    public string Base64 { get; set; } = null!;

    public DateTime FechaSubida { get; set; }

    public virtual ICollection<TbArchivosCitasLab> TbArchivosCitasLabs { get; set; } = new List<TbArchivosCitasLab>();

    public virtual ICollection<TbArchivosCitasMedica> TbArchivosCitasMedicas { get; set; } = new List<TbArchivosCitasMedica>();
}
