
namespace SaludAppBackend.Models.DTOs.AutenticacionDTOs
{
    public class AutenticacionResponse
    {
        public int IdUsuario { get; set; }
        public int IdPaciente {  get; set; }
        public int? TipoUsuario { get; set; }
        public int? Departamento { get; set; }
        public int? Municipio { get; set; }
        public int? Barrio { get; set; }
        public int? Verificado { get; set; }
    }
}
