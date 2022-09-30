using System;
using System.Collections.Generic;

namespace BOOLEANDATA2.Models
{
    public partial class Acudiente
    {
        public Acudiente()
        {
            RegistroMatriculas = new HashSet<RegistroMatricula>();
        }

        public int IdAcudiente { get; set; }
        public string? Dni { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Parentesco { get; set; }
        public string? Ocupacion { get; set; }
        public string? Clave { get; set; }
        public string? Usuario { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<RegistroMatricula> RegistroMatriculas { get; set; }
    }
}
