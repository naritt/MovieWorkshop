using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieWorkshop.Models;
using MovieWorkshop.Entity;

namespace MovieWorkshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieWorkshopDBContext _context;

        public HomeController(ILogger<HomeController> logger, MovieWorkshopDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movieList = _context.Movies.ToList();
            return View(movieList);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Genres(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return NotFound();
            }

            var movieList = _context.Movies.Where(m => m.Type.Name == type).ToList();
            return View(movieList);
        }
    }
}
