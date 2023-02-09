using GEMEscolar.Core.Entities;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface IMensalidadesService
    {
        Task GerarMensalidadesParaNovoAluno(Alunos aluno, int anoLetivo, double mensalidade, int desconto);
    }
}
