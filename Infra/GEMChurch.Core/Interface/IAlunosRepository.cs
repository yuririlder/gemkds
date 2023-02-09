using GEMEscolar.Core.Entities;
using System;
using System.Collections.Generic;

namespace GEMEscolar.Core.Interface
{
    public interface IAlunosRepository : IRepository<Alunos>
    {
        List<Alunos> GetTodosAlunosComResponsavelETurma();
        Alunos GetAlunoComResponsavelETurmaPeloId(Guid idAluno);
    }
}
