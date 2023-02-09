using System;
using System.Collections.Generic;

namespace GEMEscolar.Core.Entities
{
    public class Turmas : BaseEntity
    {
        public string Nome { get; set; }
        public string Sala { get; set; }
        public string Turno { get; set; }
        public int Capacidade { get; set; }
        public Guid ProfessorId { get; set; }

        public virtual List<Alunos> Alunos { get; set; }
        public virtual Professores Professor { get; set; }

    }
}
