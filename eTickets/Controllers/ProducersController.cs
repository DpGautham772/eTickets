using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Services;
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
        private readonly IProducersService _service;

        public ProducersController(IProducersService service, ILogger<ProducersController> logger)
        {
            _service = service;
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
            var allProducers = await _service.GetAllAsync();
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