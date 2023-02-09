using GEMEscolar.Core.Models;
using GEMEscolar.Infra.Enumerators;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GEMEscolar.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosService _alunosService;
        public AlunosController(IAlunosService alunosService)
        {   
            _alunosService = alunosService;

        }
        public async Task<ActionResult> Index(CriarAlunoResponsavelModelo novoAluno)
        {
            if(string.IsNullOrEmpty(novoAluno.DocumentoResponsavel))
                return View(novoAluno);

            var response = _alunosService.CarregarResponsavelExistente(novoAluno.DocumentoResponsavel);
            return View(response);
        } 
        [HttpPost]
        public async Task<ActionResult> CriarAluno(CriarAlunoResponsavelModelo novoAlunoEResponsavel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", novoAlunoEResponsavel);
            }

            var response = await _alunosService.CriarAluno(novoAlunoEResponsavel);
            if (!response.Success)
            {
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, response.Message);
                return View("Index", novoAlunoEResponsavel);
            }

            ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Success, response.Message);
            return RedirectToAction("Index", "Home");
        }
    }
}
