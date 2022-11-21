using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCStart.Models;

namespace MVCStart.Controllers
{
    public class ProductController : Controller
    {

        List<Product> products = new List<Product>()
        {
            new Product{Id=1, Name="iPhone 13", Price=31900, Description="iPhone 13 Descrtiption"},
            new Product{Id=2, Name="iPhone 7", Price=18900, Description="iPhone 7 Descrtiption"},
            new Product{Id=3, Name="iPhone 8", Price=24000, Description="iPhone 8 Descrtiption"},
            new Product{Id=4, Name="iPhone 14", Price=44900, Description="iPhone 14 Descrtiption"},
            new Product{Id=5, Name="iPhone 11", Price=27800, Description="iPhone 11 Descrtiption"},
            new Product{Id=6, Name="iPhone 12", Price=29900, Description="iPhone 12 Descrtiption"}
        };

        private readonly WorkshopContext _context;
        public ProductController(WorkshopContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortBy = "id", int page = 1)
        {
            ViewBag.Title = "Products";
            ViewBag.Test = "Test";

            //var data = products.AsQueryable();
            var data = _context.Products.Include(c=>c.Category).AsQueryable();


            if (sortBy== "name")
            {
                data = data.OrderBy(x => x.Name);

            }
            else if(sortBy== "price")
            {
                data = data.OrderBy(x => x.Price);

            }
            else
            {
                data = data.OrderBy(x => x.Id);
            }

            int pageSize = 10;
            int skip = (page - 1) * pageSize;

            data = data.Skip(skip).Take(pageSize);

            //int total = products.Count();
            int total = _context.Products.Count();
            double totalPage = Math.Ceiling((double)total / pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.Page = page;
            ViewBag.SortBy = sortBy;

            return View(data.ToList());
        }

        public IActionResult Details(int id)
        {
            //var data = products.SingleOrDefault(p=>p.Id == id);
            var data = _context.Products.SingleOrDefault(p => p.Id == id);
            

            if (data == null)
            {
                return Redirect("Error/404");
            }

            return View(data);
        }

        public IActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            return View("ShowData", product);
        }

        [Route("Products/Released/{year:int:regex(^\\d{{4}}$)}/{month:int:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month) 
        {
            return Content(year + " " + month);
        }
    }
}
