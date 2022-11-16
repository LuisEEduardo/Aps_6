using App.Application;
using App.DTO;
using App.DTO.Dados;
using App.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace App.Controllers
{
    [DisableCors]
    public class HomeController : Controller
    {
        private readonly IDadosAplicacao _dadosAplicacao;
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public HomeController(IDadosAplicacao dadosAplicacao, IUsuarioAplicacao usuarioAplicacao)
        {
            _dadosAplicacao = dadosAplicacao;
            _usuarioAplicacao = usuarioAplicacao;
        }


        [HttpPost()]
        public async Task<IActionResult> Index(string filePath)
        {
            using var cliente = new HttpClient();

            cliente.BaseAddress = new Uri("http://127.0.0.1:5000");

            var reconhecimentoFacial = new ReconhecimentoFacialDTO()
            {
                FilePath = @"C:\dev\faculdade\aps_6_semestre\Aps6\App\wwwroot\CameraPhotos\" + filePath.Substring(1).Remove(40)
            };

            var response = await cliente.PostAsJsonAsync<ReconhecimentoFacialDTO>("/reconhecimento", reconhecimentoFacial);

            var contents = await response.Content.ReadAsStringAsync();

            var id = int.Parse(contents.Substring(contents.IndexOf("[") + 1, contents.IndexOf(",") - 1).ToString());

            return Json(id);
        }



        [HttpGet()]
        public async Task<IActionResult> Teste(int id)
        {
            var usuario = await _usuarioAplicacao.SelecionarPorId(id);

            var dados = await _dadosAplicacao.SelecionarTodosDadosPorTipoPermissao(((int)usuario.TipoPermissao));

            return View("Index", dados);
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