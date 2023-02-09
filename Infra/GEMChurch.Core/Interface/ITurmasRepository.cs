using GEMEscolar.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Interface
{
    public interface ITurmasRepository : IRepository<Turmas>
    {
        Task<List<Turmas>> GetTodosComProfessor();
    }
}
