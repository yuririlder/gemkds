using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using GEMEscolar.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Service
{
    public class MensalidadesService : IMensalidadesService
    {
        private readonly IMensalidadesRepository _mensalidadesRepository;

        public MensalidadesService(IMensalidadesRepository mensalidadesRepository)
        {
            _mensalidadesRepository = mensalidadesRepository;
        }
        public async Task GerarMensalidadesParaNovoAluno(Alunos aluno, int anoLetivo, double mensalidade, int desconto)
        {
            var listaDeMesesRestantes = new List<int>();

            if (anoLetivo == DateTime.Now.Year)
            {
                for (var mesAtual = DateTime.Now.Month; mesAtual <= 12; mesAtual++)
                {
                    listaDeMesesRestantes.Add(mesAtual);
                }
            }
            else
            {
                for (var mesAtual = 1; mesAtual <= 12; mesAtual++)
                {
                    listaDeMesesRestantes.Add(mesAtual);
                }
            }

            foreach (var item in listaDeMesesRestantes)
            {
                var mensalidadeModel = new Mensalidades()
                {
                    AlunoId = aluno.Id,
                    Ano = anoLetivo,
                    Mes = item,
                    Quitado = false,
                    Valor = mensalidade,
                    DescontoPorcentagem = desconto,
                };

                _mensalidadesRepository.Add(mensalidadeModel);
            }
        }
    }
}
