using Microsoft.AspNetCore.Mvc;
using MVCCoreEF.Models;

namespace MVCCoreEF.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NorthwindContext _context;

        public CustomerController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortBy)
        {
            ViewBag.SortBy = sortBy == "ContactName" ? "ContactName Desc" : "ContactName";

            var data = _context.Customers.AsQueryable();

            switch (sortBy)
            {
                case "ContactName Desc": data = data.OrderByDescending(c => c.ContactName); break;
                case "ContactName": data = data.OrderBy(c=>c.ContactName); break; 
            }

            return View(data.ToList());
        }


        public IActionResult Search(string searchBy, string keyword)
        {
            ViewBag.SearchBy = searchBy;

            var data = _context.Customers.AsQueryable();

            if(searchBy == "ContactName")
            {
                data = data.Where(c => c.ContactName.Contains(keyword));
            }
            else if(searchBy == "City")
            {
                data = data.Where(c => c.City.Contains(keyword));
            }

            return View("Index", data.ToList());

        }

    }
}
