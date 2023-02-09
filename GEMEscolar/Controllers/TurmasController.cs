using GEMEscolar.Core.Entities;
using GEMEscolar.Infra.Enumerators;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Models;
using GEMEscolar.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GEMEscolar.Controllers
{
    public class TurmasController : Controller
    {
        public ITurmasService _turmasService;
        public TurmasController(ITurmasService turmasService)
        {
            _turmasService = turmasService;
        }

        public async Task<IActionResult> Index()
        {
            var painelTurmas = await _turmasService.GetTodasTurmasComProfessor();
            return View(painelTurmas);
        }
        [HttpPost]
        public async Task<IActionResult> CriarNovaTurma(PainelTurmasModel turma)
        {
            if(turma.NovaTurma.ProfessorId == System.Guid.Empty)
            {
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, "E necessário informar qual professor.");
                return View("Index", new PainelTurmasModel());
            }

            _turmasService.CriarNovaTurma(turma.NovaTurma);

            ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Success, "Turma criada com sucesso.");
            return RedirectToAction("Index", "Home");
        }

    }
}
