using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Usuarios
{
    public class InformacionGeneralPacienteModel
    {
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public string Cedula {  get; set; } = null!;
        public string Genero { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? NumeroINSS {  get; set; }
        public string Ocupacion { get; set; } = null!;
        public string Religion { get; set; } = null!;
        public string Escolaridad { get; set; } = null!;
        public int Edad {  get; set; }
        public string EstadoCivil {  get; set; } = null!;
        public int CantidadHermanos { get; set; }
    }
}
