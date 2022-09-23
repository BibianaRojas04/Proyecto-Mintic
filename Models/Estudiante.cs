using System;
using System.Collections.Generic;

namespace BOOLEANDATA.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            RegistroMatriculas = new HashSet<RegistroMatricula>();
        }

        public int IdEstudiante { get; set; }
        public string Dni { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NombreApellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string DireccionCasa { get; set; } = null!;
        public string? TelefonoCasa { get; set; }
        public string? TelefonoOpcional { get; set; }
        public string? Genero { get; set; }
        public string Email { get; set; } = null!;
        public string? ClavePassword { get; set; }

        public virtual ICollection<RegistroMatricula> RegistroMatriculas { get; set; }
    }
}
