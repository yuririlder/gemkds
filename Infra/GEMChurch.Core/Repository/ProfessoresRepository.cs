using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Repository
{
    public class ProfessoresRepository : Repository<Professores>, IProfessoresRepository
    {
        public ProfessoresRepository(GEMContext gEMContext) : base(gEMContext)
        {

        }
    }
}
