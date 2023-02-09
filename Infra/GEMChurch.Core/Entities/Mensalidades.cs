using System;

namespace GEMEscolar.Core.Entities
{
    public class Mensalidades : BaseEntity
    {
        public Guid AlunoId { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool Quitado { get; set; }
        public string Observacao { get; set; }
        public double Valor { get; set; }
        public int DescontoPorcentagem { get; set; }

        public virtual Alunos Alunos { get; set; }
    }
}
