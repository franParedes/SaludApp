using System;
using System.Collections.Generic;

namespace SaludAppBackend.Data.Models;

public partial class TbArchivosCitasLab
{
    public int ArchivoCitasLabId { get; set; }

    public int ArchivoId { get; set; }

    public int CitaId { get; set; }

    public virtual TbArchivo Archivo { get; set; } = null!;

    public virtual TbCitasLaboratorio Cita { get; set; } = null!;
}
