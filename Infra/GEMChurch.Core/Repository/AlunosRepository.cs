using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GEMEscolar.Core.Repository
{
    public class AlunosRepository : Repository<Alunos>, IAlunosRepository
    {
        public AlunosRepository(GEMContext gEMContext) : base(gEMContext)
        {

        }
        public List<Alunos> GetTodosAlunosComResponsavelETurma()
        {
            return Db.Alunos
                .Include(x => x.Responsavel).ToList();
        }
        public Alunos GetAlunoComResponsavelETurmaPeloId(Guid idAluno)
        {
            return Db.Alunos
                .Include(x => x.Responsavel).FirstOrDefault(x => x.Id == idAluno);
        }

    }
}
