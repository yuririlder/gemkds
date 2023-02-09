using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using GEMEscolar.Infra.Interface;
using System.Linq;

namespace GEMEscolar.Infra.Service
{
    public class ProfessoresService : IProfessoresService
    {
        private readonly IProfessoresRepository _professoresRepository;
        public ProfessoresService(IProfessoresRepository professoresRepository)
        {
            _professoresRepository = professoresRepository;
        }

        public bool CriarNovoProfessor(Professores professor)
        {
            var professores = _professoresRepository.GetAll();
            if(professores.Select(x => x.CPF).ToList().Contains(professor.CPF))
            {
                return false;
            }

            professor.Ativo = true;
            _professoresRepository.Add(professor);
            return true;
        }
    }
}
