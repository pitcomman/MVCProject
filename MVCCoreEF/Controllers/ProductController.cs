using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCoreEF.Models;
using X.PagedList;

namespace MVCCoreEF.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext _context;

        public ProductController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page, int? categoryId)
        {
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "CategoryName", categoryId);
            ViewBag.CategoryId = categoryId;

            if(categoryId == null)
            {
                var data = _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Supplier)
                        .OrderBy(p => p.ProductId)
                        .ToPagedList(page ?? 1, 10);
                return View(data);
            }
            else {
                var data = _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Supplier)
                        .Where(p=>p.CategoryId == categoryId)
                        .OrderBy(p => p.ProductId)
                        .ToPagedList(page ?? 1, 10);

                return View(data);
            }



            
        }
    }
}
