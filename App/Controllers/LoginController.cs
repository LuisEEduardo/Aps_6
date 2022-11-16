using App.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [DisableCors]
    public class LoginController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }        

        [HttpPost()]
        public IActionResult CapturaImagem(string name, [FromServices] IWebHostEnvironment _enviroment)
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

                        filePath = newFileName;

                        //imageBytes = System.IO.File.ReadAllBytes(filePath);                            
                    }
                }
            }
            else
            {
                return Json(false);
            }

            // return RedirectToAction("Index", "Home", new ReconhecimentoFacialDTO { FilePath = filePath });
            return Json(filePath);
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
