using App.Application;
using App.DTO;
using App.DTO.Dados;
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

        //[HttpGet()]
        //public async Task<IActionResult> Index(int id)
        //{
        //    var dados = await _dadosAplicacao.SelecionarTodosDados();

        //    return View(dados);
        //}

        //[HttpGet()]
        //public async Task<IActionResult> Index(ReconhecimentoFacialDTO reconhecimentoFacialDTO)
        //{

        //    using var cliente = new HttpClient();

        //    cliente.BaseAddress = new Uri("http://127.0.0.1:5000");

        //    //var reconhecimentoFacial = new ReconhecimentoFacialDTO()
        //    //{
        //    //    FilePath = filePath
        //    //};

        //    var response = await cliente.PostAsJsonAsync<ReconhecimentoFacialDTO>("/reconhecimento", reconhecimentoFacialDTO);

        //    var contents = await response.Content.ReadAsStringAsync();

        //    var id = int.Parse(contents.Substring(contents.IndexOf("[") + 1, contents.IndexOf(",") - 1).ToString());

        //    var dados = await _dadosAplicacao.SelecionarTodosDados();

        //    return RedirectToAction("Teste", new { dados });
        //}
        
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

            return Json( new { dados });
        }

        [HttpGet("teste")]
        public IActionResult Teste(List<DetalharDadoDTO> detalharDadoDTOs)
        {
            return View("Index", detalharDadoDTOs);
        }


        //[HttpPost()]
        //public IActionResult CapturaImagem(string name, [FromServices] IWebHostEnvironment _enviroment)
        //{

        //    var files = HttpContext.Request.Form.Files;
        //    string filePath = "";

        //    if (files != null)
        //    {
        //        foreach (var file in files)
        //        {
        //            if (file.Length > 0)
        //            {
        //                var fileName = file.FileName;
        //                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
        //                var fileExtension = Path.GetExtension(fileName);
        //                var newFileName = string.Concat(myUniqueFileName, fileExtension);
        //                filePath = Path.Combine(_enviroment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";
        //                if (!string.IsNullOrEmpty(filePath))
        //                {
        //                    ArmazenarDiretorio(file, filePath);
        //                }

        //                //imageBytes = System.IO.File.ReadAllBytes(filePath);                            
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return Json(false);
        //    }

        //    // return RedirectToAction("Index", "Home", new ReconhecimentoFacialDTO { FilePath = filePath });
        //    return Json(new ReconhecimentoFacialDTO { FilePath = filePath });
        //}



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