using System;
using System.Collections.Generic;

namespace BOOLEANDATA.Models
{
    public partial class Acudiente
    {
        public Acudiente()
        {
            RegistroMatriculas = new HashSet<RegistroMatricula>();
        }

        public int IdAcudiente { get; set; }
        public string Dni { get; set; } = null!;
        public string TipoDocumento { get; set; } = null!;
        public string NombreApellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string DireccionCasa { get; set; } = null!;
        public string? TelefonoCasa { get; set; }
        public string? TelefonoOpcional { get; set; }
        public string? Genero { get; set; }
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;
        public bool? Parentesco { get; set; }
        public string DireccionTrabajo { get; set; } = null!;

        public virtual ICollection<RegistroMatricula> RegistroMatriculas { get; set; }
    }
}
