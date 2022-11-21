using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCStart.Models;
using System.Diagnostics;
using System.Text;

namespace MVCStart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<string> provinces = new List<string>()
        {
            "Bangkok", "Phuket", "Patumtani", "Nontaburi"
        };

        private List<string> hobbies = new List<string>()
        {
            "Shopping", "Swimming", "Hiking", "Play Game", "Running"
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Survey()
        {
            //เป็นตัวเลือกใน Dropdown
            ViewBag.Province = new SelectList(provinces);
            ViewBag.Hobby = hobbies;

            return View();
        }

        [HttpPost]
        public IActionResult Survey(IFormCollection frm)
        {
            ViewBag.Province = new SelectList(provinces);
            ViewBag.Hobby = hobbies;

            StringBuilder sb = new StringBuilder();
            sb.Append($"<b>Name: </b>{frm["name"]}<br>");
            sb.Append($"<b>Password: </b>{frm["password"]}<br>");
            sb.Append($"<b>Gender: </b>{frm["gender"]}<br>");
            //sb.Append($"<b>Hobby: </b>{frm["hobby1"]} {frm["hobby2"]} {frm["hobby3"]}<br>");

            
            string hobby = "";
            for(int i=0; i<hobbies.Count; i++)
            {
                if (frm["hobby" + i] == hobbies[i])
                {
                    if (hobby == "")
                    {
                        hobby = frm["hobby" + i];
                    }
                    else
                    {
                        hobby += ", " + frm["hobby" + i];
                    }
                }
            }

            sb.Append($"<b>Hobby: </b>{hobby}<br>");

            //foreach(var item in hobbies) 
            //{
            //    sb.Append($"<b>Hobby: " + item + "</b>");
            //}


            sb.Append($"<b>Province: </b>{frm["province"]}<br>");
            sb.Append($"<b>Code: </b>{frm["code"]}<br>");

            ViewBag.Data = sb.ToString();


            return View(); 
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CheckEmail(string email)
        {

            //ถ้าไม่เท่ากับ  pit_dragonforce@hotmail.com คือให้ผ่าน
            var result = email.ToLower() != "Pit_dragonforce@hotmail.com".ToLower();

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}