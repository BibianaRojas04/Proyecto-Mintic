using System;
using System.Collections.Generic;

namespace BOOLEANDATA2.Models
{
    public partial class RegistroMatricula
    {
        public int IdMatricula { get; set; }
        public DateTime? FechaMatricula { get; set; }
        public double? ValorMatricula { get; set; }
        public int IdEstudiante1 { get; set; }
        public int IdAcudiente1 { get; set; }
        public int IdPersonaAdmi1 { get; set; }
        public string? Curso { get; set; }

        public virtual Acudiente IdAcudiente1Navigation { get; set; } = null!;
        public virtual Estudiante IdEstudiante1Navigation { get; set; } = null!;
        public virtual PersonalAdmin IdPersonaAdmi1Navigation { get; set; } = null!;
    }
}
