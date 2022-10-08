using App.Application;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDadosAplicacao _dadosAplicacao;

        public HomeController(IDadosAplicacao dadosAplicacao)
        {
            _dadosAplicacao = dadosAplicacao;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _dadosAplicacao.SelecionarTodosDados();

            return View(dados);
        }

    }
}