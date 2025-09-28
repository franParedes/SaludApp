using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Usuarios
{
    public class UsuarioModel
    {
        public string Cedula { get; set; } = null!;
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenya { get; set; } = null!;
        public int Genero { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int TipoUsuario { get; set; }
    }
}
