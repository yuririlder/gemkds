using GEMEscolar.Core.Controllers;
using GEMEscolar.Core.Entities;
using GEMEscolar.Infra.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GEMEscolar.Controllers
{
    public class PagamentoController : MainControllerApi
    {
        public IPagamentoService _pagamentoService;
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        public async Task<IActionResult> Index(Guid alunoId)
        {
            return View();
        }
        public async Task<IActionResult> PagamentoAluno(Guid alunoId)
        {
            var userLogado = HttpContext.Session.GetObjectFromJson<Users>("UserLogado");

            return View("Index");
        }

    }
}
