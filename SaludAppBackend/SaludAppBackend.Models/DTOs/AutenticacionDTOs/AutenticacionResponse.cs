
namespace SaludAppBackend.Models.DTOs.AutenticacionDTOs
{
    public class AutenticacionResponse
    {
        public int IdUsuario { get; set; }
        public int? TipoUsuario { get; set; }
        public int Verificado { get; set; }
    }
}
