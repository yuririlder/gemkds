using GEMEscolar.Core.Entities;
using GEMEscolar.Infra.Models;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface ITurmasService
    {
        Task<PainelTurmasModel> GetTodasTurmasComProfessor();
        void CriarNovaTurma(Turmas turma);
    }
}
