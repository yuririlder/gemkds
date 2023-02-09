using GEMEscolar.Core.Entities;
using GEMEscolar.Infra.Enumerators;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GEMEscolar.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly IProfessoresService _professoresService;
        public ProfessoresController(IProfessoresService professoresService)
        {
            _professoresService = professoresService;
        }

        public async Task<IActionResult> Index(Professores? professores)
        {
            if(professores == null)
            {
                return View();
            }
            return View(professores);
        }
        [HttpPost]
        public IActionResult CriarNovoProfessor(Professores professor)
        {
            var professorCriado = _professoresService.CriarNovoProfessor(professor);

            if (!professorCriado)
            {
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, "Professor já existe.");
                return View("Index", professor);
            }
            
            ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Success, "Professor criado com sucesso.");
            return View("Index", new Professores());
        }
    }
}
