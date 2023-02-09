using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GEMEscolar.Core.Repository
{
    public class ResponsavelRepository : Repository<Responsavel>, IResponsavelRepository
    {
        public ResponsavelRepository(GEMContext gEMContext) : base(gEMContext)
        {

        }

        public Responsavel GetResponsavelPeloCPFComAlunos(string cpf)
        {
            return Db.Responsavel
                .Include(x => x.Alunos)
                .Where(x => x.Cpf == cpf).FirstOrDefault();
        }

    }
}
