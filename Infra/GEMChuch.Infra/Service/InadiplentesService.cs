using GEMEscolar.Core.Interface;
using GEMEscolar.Core.Models;
using GEMEscolar.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Service
{
    public class InadiplentesService : IInadiplentesService
    {
        private readonly IMensalidadesRepository _mensalidadesRepository;
        private readonly IAlunosRepository _alunosRepository;
        public InadiplentesService(IMensalidadesRepository mensalidadesRepository, IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
            _mensalidadesRepository = mensalidadesRepository;
        }

        public async Task<List<InadiplentesModel>> GetListaDeInadimplentes()
        {
            var mensalidades = await _mensalidadesRepository.GetAllAsync();

            var mensalidadesAgrupadas = 
                mensalidades.ToList()
                    .GroupBy(x => x.AlunoId)
                    .ToDictionary(x => x.Key, x => x.ToList());

            var listaDeInadimplentes = new List<InadiplentesModel>();
            foreach (var item in mensalidadesAgrupadas)
            {
                var inadiplente = new InadiplentesModel();

                var aluno = _alunosRepository.GetAlunoComResponsavelETurmaPeloId(item.Key);

                inadiplente.Id = aluno.Id;
                inadiplente.NomeResponsavel = aluno.Responsavel.Nome;
                inadiplente.NomeAluno = aluno.NomeAluno;
                inadiplente.Telefone = aluno.Responsavel.Telefone;

                var quantidadeDeMensalidadesAtrasadas = new List<int>();
                var count = 0;
                foreach (var mensalidade in item.Value)
                {
                    if(mensalidade.Quitado == false 
                        && mensalidade.Mes <= DateTime.Now.Month
                            && mensalidade.Ano <= DateTime.Now.Year)
                    {
                        quantidadeDeMensalidadesAtrasadas.Add(count);
                        count++;
                    }       
                }

                if(quantidadeDeMensalidadesAtrasadas.Count > 0)
                {
                    inadiplente.QntidadeDeparcelas = quantidadeDeMensalidadesAtrasadas.Count();
                    inadiplente.ValorTotal = (quantidadeDeMensalidadesAtrasadas.Count() * aluno.MensalidadeValor);

                    listaDeInadimplentes.Add(inadiplente);
                }
            }

            return listaDeInadimplentes.OrderByDescending(x => x.QntidadeDeparcelas).ToList();
        }
        
    }
}
