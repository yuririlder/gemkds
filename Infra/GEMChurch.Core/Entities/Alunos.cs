using System;
using System.Collections.Generic;

namespace GEMEscolar.Core.Entities
{
    public class Alunos : BaseEntity
    {
        public string NomeAluno { get; set; }
        public string Sexo { get; set; }
        public string Naturalidade { get; set; }
        public double MensalidadeValor { get; set; }
        public int DescontaEmPorcentagem { get; set; }
        public string Observacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; }
        public Guid? ResponsavelId { get; set; }
        public Guid? TurmaId { get; set; }

        public virtual Responsavel Responsavel { get; set; }    
        public virtual Turmas Turmas { get; set; }    
        public virtual List<Mensalidades> Mensalidades { get; set; }    
    }
}
