using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Usuarios
{
    public class Administrador : UsuarioModel
    {
        public int CentroActual { get; set; }
    }
}
