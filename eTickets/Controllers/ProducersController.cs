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
    [Route("Producers")]
    public class ProducersController : Controller
    {
        private readonly ILogger<ProducersController> _logger;
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context, ILogger<ProducersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // public ProducersController(ILogger<ProducersController> logger)
        // {
        //     _logger = logger;
        // }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View(allProducers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("Error")]
        public async Task<IActionResult> Error()
        {
            return View("Error!");
        }
    }
}