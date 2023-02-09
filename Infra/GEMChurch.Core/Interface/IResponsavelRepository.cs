using GEMEscolar.Core.Entities;

namespace GEMEscolar.Core.Interface
{
    public interface IResponsavelRepository : IRepository<Responsavel>
    {
        Responsavel GetResponsavelPeloCPFComAlunos(string cpf);
    }
}
