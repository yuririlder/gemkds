using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Repository
{
    public class TurmasRepository : Repository<Turmas>, ITurmasRepository
    {
        public TurmasRepository(GEMContext gEMContext) : base(gEMContext)
        {

        }

        public async Task<List<Turmas>> GetTodosComProfessor()
        {
            return Db.Turmas
                .Include(x => x.Professor).ToList();
        }
    }
}
