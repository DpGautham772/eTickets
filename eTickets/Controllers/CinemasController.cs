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
    [Route("Cinemas")]
    public class CinemasController : Controller
    {
        private readonly ILogger<CinemasController> _logger;

        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context, ILogger<CinemasController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _context.Cinemas.ToListAsync();
            return View(allCinemas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("Error")]
        public async Task<IActionResult> Error()
        {
            return View("Error!");
        }
    }
}