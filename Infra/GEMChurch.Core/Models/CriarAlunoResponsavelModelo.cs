using System;
namespace GEMEscolar.Core.Models
{
    public class CriarAlunoResponsavelModelo
    {
        public Guid IdAluno { get; set; }
        public string NomeAluno { get; set; }
        public string Sexo { get; set; }
        public string Naturalidade { get; set; }
        public double MensalidadeValor { get; set; }
        public string Observacao { get; set; }
        public int AnoLetivo { get; set; }
        public int DescontaEmPorcentagem { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid AlunosResponsavelId { get; set; }
        public Guid TurmaId { get; set; }
        public Guid MensalidadeId { get; set; }
        public Guid IdResponsavel { get; set; }
        public string NomeResponsavel { get; set; }
        public string DocumentoResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string TelefoneResponsavel2 { get; set; }
        public string EnderecoResponsavel { get; set; }
        public string CidadeResponsavel { get; set; }
        public string EstadoResponsavel { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
    }
}
