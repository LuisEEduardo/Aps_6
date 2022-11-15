using App.Application;
using App.DTO;
using App.DTO.Dados;
using App.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    [DisableCors]
    public class HomeController : Controller
    {
        private readonly IDadosAplicacao _dadosAplicacao;

        public HomeController(IDadosAplicacao dadosAplicacao)
        {
            _dadosAplicacao = dadosAplicacao;
        }

        [HttpPost()]
        public async Task<IActionResult> Index([FromBody] string filePath)
        {
            using var cliente = new HttpClient();

            cliente.BaseAddress = new Uri("http://127.0.0.1:5000");

            var reconhecimentoFacial = new ReconhecimentoFacialDTO()
            {
                FilePath = filePath
            };

            var response = await cliente.PostAsJsonAsync<ReconhecimentoFacialDTO>("/reconhecimento", reconhecimentoFacial);

            var contents = await response.Content.ReadAsStringAsync();

            var id = int.Parse(contents.Substring(contents.IndexOf("[") + 1, contents.IndexOf(",") - 1).ToString());

            var dados = await _dadosAplicacao.SelecionarTodosDados();

            //return RedirectToAction("Teste", new { dados });

            return Json(new { dados });
        }

        [HttpGet("teste")]
        public IActionResult Teste(List<DetalharDadoDTO> detalharDadoDTOs)
        {
            return View("Index", detalharDadoDTOs);
        }

        private void ArmazenarDiretorio(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}