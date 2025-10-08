using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Usuarios
{
    public class PacienteModel : UsuarioModel
    {
        //public UsuarioModel GeneralInfo { get; set; } = null!;
        public string? NumeroInss { get; set; }
        public int Ocupacion { get; set; }
        public int Escolaridad { get; set; }
        public int Religion { get; set; }
        public int Edad { get; set; }
        public int EstadoCivil { get; set; }
        public int CantidadHermanos { get; set; }
    }

    public class TelefonoModel
    {
        public int Telefono { get; set; }
        public int Compania { get; set; }
    }

    public class DireccionesModel
    {
        public int Departamento { get; set; }
        public int Municipio { get; set; }
        public int Barrio { get; set; }
        public string Direccion { get; set; } = null!;
    }
}
