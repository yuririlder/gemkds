using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;

namespace GEMEscolar.Core.Repository
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(GEMContext gEMContext) : base(gEMContext)
        {

        }

    }
}
