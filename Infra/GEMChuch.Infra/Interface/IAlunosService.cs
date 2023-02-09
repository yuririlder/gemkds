using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Models;
using GEMEscolar.Infra.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface IAlunosService
    {
        Task<ValidationResult> CriarAluno(CriarAlunoResponsavelModelo alunoResponsavelModelo);
        Task<List<Alunos>> GetTodosAlunosComResponsavelETurma();
        CriarAlunoResponsavelModelo CarregarResponsavelExistente(string documentoResponsavel);
        Task<Alunos> GetAlunoComResponsavelETurmaPeloId(Guid idAluno);
    }
}
