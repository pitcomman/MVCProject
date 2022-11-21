using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCoreEF.Models;

namespace MVCCoreEF.Controllers
{
    public class UserController : Controller
    {

        private readonly NorthwindContext _context;
        public UserController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var data = _context.Users.ToList();

            return View(data);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var data = _context.Users.SingleOrDefault(u=>u.Id== id);
            if(data == null)
            {
                return NotFound();  
            }
            return View(data);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _context.Users.SingleOrDefault(u => u.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                var data = _context.Users.SingleOrDefault(u=>u.Id== user.Id);
                data.Name = user.Name;
                data.Address = user.Address;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Users.SingleOrDefault(u => u.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                //Find ใช้สำหรับตัวที่เป็น Key หลักแน่นอน
                var data = _context.Users.Find(id);
                if (data == null)
                {
                    return NotFound();
                }
                _context.Users.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
