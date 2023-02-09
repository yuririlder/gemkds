using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;

namespace GEMEscolar.Core.Repository
{
    public class MensalidadesRepository : Repository<Mensalidades>, IMensalidadesRepository
    {
        public MensalidadesRepository(GEMContext gEMContext) : base(gEMContext)
        {

        }
    }
}
