using App.DTO;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> CapturaImagem(string name, [FromServices] IWebHostEnvironment _enviroment)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                string filePath = "";

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                            var fileExtension = Path.GetExtension(fileName);
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);
                            filePath = Path.Combine(_enviroment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                ArmazenarDiretorio(file, filePath);
                            }

                            //imageBytes = System.IO.File.ReadAllBytes(filePath);                            
                        }
                    }                    
                }
                else
                {
                    return Json(false);
                }

                //var fileOpen = new FileStream(filePath, FileMode.Open);

                using var cliente = new HttpClient();

                cliente.BaseAddress = new Uri("http://127.0.0.1:5000");

                var reconhecimentoFacial = new ReconhecimentoFacialDTO()
                {
                    FilePath = filePath
                };
                
                var response = await cliente.PostAsJsonAsync<ReconhecimentoFacialDTO>("/reconhecimento", reconhecimentoFacial);

                var contents = await response.Content.ReadAsStringAsync();

                var id = int.Parse(contents.Substring(contents.IndexOf("[") + 1, contents.IndexOf(",") - 1).ToString());

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home", new { id });

                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return Json(false);
            }            
        }


        //[HttpGet("reconhecimentoFacial")]
        //public IActionResult ReconhecimentoFacial(FileStream file)
        //{
        //    using var cliente = new HttpClient();

        //    cliente.BaseAddress = new Uri("http://127.0.0.1:5000");

        //    var reconhecimentoFacial = new ReconhecimentoFacialDTO()
        //    {
        //        File = file
        //    };

        //    var post = cliente.PostAsJsonAsync<ReconhecimentoFacialDTO>("reconhecimento", reconhecimentoFacial);
        //    post.Wait();
        //    var result = post.Result;

        //    if (result.IsSuccessStatusCode)
        //        return RedirectToAction("Home", result.Content);

        //    return RedirectToAction("Index");
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
