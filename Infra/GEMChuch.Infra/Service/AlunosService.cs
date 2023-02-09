using AutoMapper;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using GEMEscolar.Core.Models;
using GEMEscolar.Infra.Enumerators;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Service
{
    public class AlunosService : IAlunosService
    {
        public readonly IMapper _mapper;
        private readonly IAlunosRepository _alunosRepository;
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IMensalidadesService _mensalidadesService;
        public AlunosService(IMapper mapper, IMensalidadesService mensalidadesService,
            IAlunosRepository alunosRepository, IResponsavelRepository responsavelRepository)
        {
            _mapper = mapper;
            _alunosRepository = alunosRepository;
            _mensalidadesService = mensalidadesService;
            _responsavelRepository = responsavelRepository;

        }

        public async Task<ValidationResult> CriarAluno(CriarAlunoResponsavelModelo alunoResponsavelModelo)
        {
            try
            {
                var responsavel = new Responsavel();
                var aluno = _mapper.Map<Alunos>(alunoResponsavelModelo);

                responsavel = _responsavelRepository.GetResponsavelPeloCPFComAlunos(alunoResponsavelModelo.Cpf);
                if (responsavel is null)
                {
                    responsavel = _mapper.Map<Responsavel>(alunoResponsavelModelo);
                    await _responsavelRepository.AddAsync(responsavel);
                }

                aluno.ResponsavelId = responsavel.Id;
                aluno.CriadoEm = DateTime.Now;
                aluno.Id = Guid.NewGuid();
                await _alunosRepository.AddAsync(aluno);

                await _mensalidadesService.GerarMensalidadesParaNovoAluno(aluno, alunoResponsavelModelo.AnoLetivo, alunoResponsavelModelo.MensalidadeValor, alunoResponsavelModelo.DescontaEmPorcentagem);

                return new ValidationResult()
                {
                    ResultType = ResultType.Success,
                    Success = true,
                    Message = $"Aluno {aluno.NomeAluno} e responsável {responsavel.Nome}, foram criados com sucesso."
                };
            }
            catch (Exception ex)
            {

                return new ValidationResult()
                {
                    ResultType = ResultType.Success,
                    Success = true,
                    Message = $"Erro ao criar usuaria com responsável. Erro: {ex}"
                };
            }
        }
        public async Task<Alunos> GetAlunoComResponsavelETurmaPeloId(Guid idAluno)
        {
            var aluno = _alunosRepository.GetAlunoComResponsavelETurmaPeloId(idAluno);
            return aluno;
        }
        public async Task<List<Alunos>> GetTodosAlunosComResponsavelETurma()
        {
            var alunos = _alunosRepository.GetTodosAlunosComResponsavelETurma();
            return alunos;
        }
        public CriarAlunoResponsavelModelo CarregarResponsavelExistente(string documentoResponsavel)
        {
            var responsavel = _responsavelRepository.GetResponsavelPeloCPFComAlunos(documentoResponsavel);
            var alunoResponsavelModeloMap = _mapper.Map<CriarAlunoResponsavelModelo>(responsavel);
            return alunoResponsavelModeloMap;
        }

    }
}
