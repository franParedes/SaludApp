using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbArchivosCitasMedica
{
    public int ArchivoCitasMedId { get; set; }

    public int ArchivoId { get; set; }

    public int CitaId { get; set; }

    public virtual TbArchivo Archivo { get; set; } = null!;

    public virtual TbCitasMedica Cita { get; set; } = null!;
}
