using GEMEscolar.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface IInadiplentesService
    {
        Task<List<InadiplentesModel>> GetListaDeInadimplentes();
    }
}
