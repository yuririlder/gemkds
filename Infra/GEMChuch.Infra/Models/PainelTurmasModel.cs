using GEMEscolar.Core.Entities;
using System.Collections.Generic;

namespace GEMEscolar.Infra.Models
{
    public class PainelTurmasModel
    {
        public List<Turmas> Turmas { get; set; } = new List<Turmas>();
        public List<Professores> Professores { get; set; } = new List<Professores>();
        public Turmas NovaTurma { get; set; } = new Turmas();
    }
}
