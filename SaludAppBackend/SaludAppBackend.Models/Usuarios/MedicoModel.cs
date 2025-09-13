using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Models.Usuarios
{
    public class MedicoModel
    {
        public MedicoModel()
        {
            Telefonos = [];
        }

        public UsuarioModel GeneralInfo { get; set; } = null!;
        public string Cod_sanitario { get; set; } = null!;
        public int Especialidad { get; set; }
        public int EgresadoDe {  get; set; }
        public DateOnly EgresadoEl {  get; set; }
        public int Experiencia_anyos { get; set; }
        public int Area_actual {  get; set; }
        public int Centro_actual { get; set; }
        public int Turno_actual { get; set; }
        public List<TelefonoModel> Telefonos { get; set; }
    }
}
