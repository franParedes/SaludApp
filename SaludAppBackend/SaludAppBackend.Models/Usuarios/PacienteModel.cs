using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Usuarios
{
    public class PacienteModel
    {
        public PacienteModel()
        {
            Telefonos = [];
            Direcciones = [];
        }

        public UsuarioModel GeneralInfo { get; set; } = null!;
        public string? NumeroInss { get; set; }
        public int Ocupacion { get; set; }
        public string Escolaridad { get; set; } = null!;
        public int Religion { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; } = null!;
        public int CantidadHermanos { get; set; }
        public List<TelefonoModel> Telefonos { get; set; }
        public List<DireccionesModel> Direcciones { get; set; }
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
