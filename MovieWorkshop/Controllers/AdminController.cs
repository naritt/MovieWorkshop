using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieWorkshop.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieWorkshop.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieWorkshopDBContext _context;

        public AdminController(MovieWorkshopDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index([Bind("Username, Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                var exists = _context.Admins.Where(a => a.Username.Equals(admin.Username) && a.Password.Equals(admin.Password)).Any();
                if (exists)
                {
                    HttpContext.Session.SetInt32("isLogin", 1);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "username or password is invalid");
            return View(admin);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Management()
        {
            var movieList = _context.Movies.ToList();
            return View(movieList);
        }

        public IActionResult Create()
        {
            ViewBag.MovieType = new SelectList(_context.MovieTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create([Bind("Name,TypeId,Description,ImageUrl,TrailerUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Management));
            }
            
            ViewBag.MovieType = new SelectList(_context.MovieTypes, "Id", "Name");
            return View(movie);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            
            ViewBag.MovieType = new SelectList(_context.MovieTypes, "Id", "Name");
            return View(movie);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name,TypeId,Description,ImageUrl,TrailerUrl")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Management));
            }
            
            ViewBag.MovieType = new SelectList(_context.MovieTypes, "Id", "Name");
            return View(movie);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            
            return View(movie);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Management));
        }
    }
}
