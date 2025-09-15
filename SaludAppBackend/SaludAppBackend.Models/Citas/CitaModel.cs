using SaludAppBackend.Models.Archivos;


namespace SaludAppBackend.Models.Citas
{
    public class CitaModel
    {
        public CitaModel() 
        {
            Adjuntos = [];
        }

        public int PacienteId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int Lugar {  get; set; }
        public DateTime? FechaCita { get; set; }
        public string? Estado { get; set; }
        public string? MotivoCita { get; set; }
        public string? MotivoRechazo { get; set; }
        public int TipoCita { get; set; }
        public List<ArchivoBaseModel> Adjuntos { get; set; }
    }
}
