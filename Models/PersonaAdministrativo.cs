using System;
using System.Collections.Generic;

namespace BOOLEANDATA.Models
{
    public partial class PersonaAdministrativo
    {
        public PersonaAdministrativo()
        {
            RegistroMatriculas = new HashSet<RegistroMatricula>();
        }

        public int IdPersonalAdministrativo { get; set; }
        public string Dni { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NombreApellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string DireccionCasa { get; set; } = null!;
        public string? TelefonoCasa { get; set; }
        public string? TelefonoOpcional { get; set; }
        public string? Genero { get; set; }
        public string Email { get; set; } = null!;
        public int ContraseñaAdmin { get; set; }
        public string Cargo { get; set; } = null!;
        public double SalarioPersonalAdmin { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Eps { get; set; } = null!;
        public string Contacto { get; set; } = null!;
        public string TelefonoContacto { get; set; } = null!;

        public virtual ICollection<RegistroMatricula> RegistroMatriculas { get; set; }
    }
}
