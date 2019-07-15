using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Controllers
{
    public class UploadController:Controller
    {
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");

                var path = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("wwwroot", "images"),
                    file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Content($"File {file.FileName} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
    }
}
