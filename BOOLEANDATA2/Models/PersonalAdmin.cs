using System;
using System.Collections.Generic;

namespace BOOLEANDATA2.Models
{
    public partial class PersonalAdmin
    {
        public PersonalAdmin()
        {
            RegistroMatriculas = new HashSet<RegistroMatricula>();
        }

        public int IdPerAdm { get; set; }
        public string? Dni { get; set; }
        public string? Rol { get; set; }
        public string? Clave { get; set; }
        public string? Usuario { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<RegistroMatricula> RegistroMatriculas { get; set; }
    }
}
