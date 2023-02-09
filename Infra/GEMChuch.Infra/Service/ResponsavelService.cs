using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using GEMEscolar.Infra.Interface;
using System.Collections.Generic;

namespace GEMEscolar.Infra.Service
{
    public class ResponsavelService : IResponsavelService
    {
        private readonly IResponsavelRepository _responsavelRepository;
        public ResponsavelService(IResponsavelRepository responsavelRepository)
        {
            _responsavelRepository = responsavelRepository;

        }

        public Responsavel GetResponsavelPeloCPF(string cpf)
        {
            return _responsavelRepository.GetResponsavelPeloCPFComAlunos(cpf);
        }
        public List<Responsavel> GetTodosResponsaveis()
        {
            return _responsavelRepository.GetAll();
        }
    }
}
