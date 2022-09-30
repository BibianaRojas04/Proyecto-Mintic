using System;
using System.Collections.Generic;

namespace BOOLEANDATA2.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            RegistroMatriculas = new HashSet<RegistroMatricula>();
        }

        public int IdEstudiante { get; set; }
        public string? Dni { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Curso { get; set; }

        public virtual ICollection<RegistroMatricula> RegistroMatriculas { get; set; }
    }
}
