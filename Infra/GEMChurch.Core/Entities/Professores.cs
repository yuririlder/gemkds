using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Entities
{
    public class Professores : BaseEntity
    {
        public string Nome { get; set; }
        public string Salario { get; set; }
        public string ChavePix { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public bool Ativo { get; set; }

        public virtual List<Turmas> Turmas { get; set; }
    }
}
