using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.DTOs.UsuariosDTO
{
    public class UsuarioPorTipoDTO
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public int? TipoUsuario { get; set; }
        public int? Activo { get; set; }
    }
}
