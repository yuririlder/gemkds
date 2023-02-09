using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Models;
using GEMEscolar.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Service
{
    public  class HomeService : IHomeService
    {
        private readonly IAlunosService _AlunosService;
        private readonly IInadiplentesService _inadiplentesService;

        public HomeService(IAlunosService alunosService, IInadiplentesService inadiplentesService)
        {
            _inadiplentesService = inadiplentesService;
            _AlunosService = alunosService;
        }
        public async Task<InformacoesDePainelModelo> CarregarInformacoesDePainel()
        {
            var alunos = await _AlunosService.GetTodosAlunosComResponsavelETurma();
            if(alunos is null)
                return null;

            var listaParaPainel = new InformacoesDePainelModelo();


            foreach(var item in alunos.OrderByDescending(x=> x.CriadoEm))
            {
                var alunosCriadosRecente = new AlunoCriadoRecenteModel()
                {
                    Alunos = item,
                    Responsavel = item.Responsavel,
                    Turmas = item.Turmas,
                };

                listaParaPainel.AlunoCriadoRecenteModels.Add(alunosCriadosRecente);

            }

            listaParaPainel.Inadiplentes = await _inadiplentesService.GetListaDeInadimplentes();

            return listaParaPainel;
        }
    }
}
