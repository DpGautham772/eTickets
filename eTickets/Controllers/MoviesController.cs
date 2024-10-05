using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eTickets.Controllers
{
    [Route("Movies")]
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context, ILogger<MoviesController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            return View(allMovies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("Error")]
        public async Task<IActionResult> Error()
        {
            return View("Error!");
        }
    }
}