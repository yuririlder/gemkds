using System.Collections.Generic;

namespace GEMEscolar.Core.Entities
{
    public class Responsavel : BaseEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public virtual List<Alunos> Alunos { get; set; }

    }
}
