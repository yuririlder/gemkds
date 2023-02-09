using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Service
{
    public class TurmasService : ITurmasService
    {
        private readonly ITurmasRepository _turmasRepository;
        private readonly IProfessoresRepository _professoresRepository;
        public TurmasService(ITurmasRepository turmasRepository, IProfessoresRepository professoresRepository)
        {

            _turmasRepository = turmasRepository;
            _professoresRepository = professoresRepository;
        }

        public async Task<PainelTurmasModel> GetTodasTurmasComProfessor()
        {
            var painelTurmas = new PainelTurmasModel();
            var turmas = await _turmasRepository.GetTodosComProfessor();
            var professores = await _professoresRepository.GetAllAsync();

            painelTurmas.Turmas = turmas;
            painelTurmas.Professores = professores;
            return painelTurmas;

        }

        public void CriarNovaTurma(Turmas turma)
        {
            _turmasRepository.Add(turma);
        }
    }
}
 