
namespace SaludAppBackend.Models.Archivos
{
    public class ArchivoBaseModel
    {
        public string NombreArchivo { get; set; } = null!;
        public string TipoArchivo { get; set; } = null!;
        public string TipoMime { get; set; } = null!;
        public byte[] BytesArchivo { get; set; } = null!;
        //public DateTime FechaCarga { get; set; } //No viene en la petición
        //public string? Base64 { get; set; } //No viene en la petición
    }
}
