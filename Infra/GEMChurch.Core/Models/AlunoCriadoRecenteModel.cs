using GEMEscolar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Models
{
    public class AlunoCriadoRecenteModel
    {
        public Alunos Alunos { get; set; }
        public Responsavel Responsavel { get; set; }
        public Turmas Turmas { get; set; }
    }
}
