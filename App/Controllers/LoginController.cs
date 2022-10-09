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
        public IActionResult CapturaImagem(string name, [FromServices] IWebHostEnvironment _enviroment)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;

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
                            var filePath = Path.Combine(_enviroment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                ArmazenarDiretorio(file, filePath);
                            }

                            // var imageBytes = System.IO.File.ReadAllBytes(filePath);
                            
                        }
                    }

                    return Json(true);
                }
                else
                {
                    return Json(false);
                }

            }
            catch (Exception)
            {

                throw;
            }            
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
