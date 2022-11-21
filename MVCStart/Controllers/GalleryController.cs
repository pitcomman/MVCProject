using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MVCStart.Controllers
{
    public class GalleryController : Controller
    {
        private String dataPath;

        public GalleryController()
        {
            dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "gallery.txt");
        }

        public IActionResult Index()
        {
            var data = System.IO.File.ReadAllLines(dataPath);
            string gallery = "";

            foreach(string item in data)
            {
                gallery += $"<div class='col-lg-4 mb-2'><img src='images/{item}' class='img-thumbnail'></div>";
            }
            ViewBag.Gallery = gallery;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                ViewBag.Message = "<div class='text-danger'>โปรดเลือกรูปภาพ</div>";
            }
            else
            {
                string name = file.FileName;
                string type = file.ContentType;
                long size = file.Length;

                if(type != "image/jpeg" && type != "image/png")
                {
                    ViewBag.Message = "<div class='text-danger'>รูปภาพต้องเป็น .jpg หรือ .png เท่านั้น</div>";
                }
                else if(size > 800 * 1024)
                {
                    ViewBag.Message = "<div class='text-danger'>ขนาดรูปภาพต้องไม่เกิน 800KB</div>";
                }
                else
                {
                    name = Guid.NewGuid() + "-" + name;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", name);

                    using(var steam = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(steam);
                    }

                    System.IO.File.AppendAllText(dataPath, name + "\n");

                    StringBuilder sb = new StringBuilder();
                    sb.Append($"<b>Name: </b>{name}<br>");
                    sb.Append($"<b>Type: </b>{type}<br>");
                    sb.Append($"<b>Size: </b>{size.ToString("#,##0")} byte(s)<br>");

                    ViewBag.Message = sb.ToString();

                    return RedirectToAction("Index");
                }


            }

            return View();
        }
    }
}
