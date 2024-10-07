using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Services;
using eTickets.Models;
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

        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service, ILogger<CinemasController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinemas/Create

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View(new Cinema());
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(cinema);  // If invalid, return the same view with errors
            }

            // Save actor to the database (assuming your _service handles async)
            await _service.AddAsync(cinema);  // Ensure this is awaited

            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) { return View("NotFound"); }
            return View(cinemaDetails);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) { return View("NotFound"); }
            return View(cinemaDetails);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

            // Save actor to the database (assuming your _service handles async)
            await _service.DeleteAsync(id);  // Ensure this is awaited

            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) { return View("NotFound"); }
            return View(cinemaDetails);
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(cinema);  // If invalid, return the same view with errors
            }

            // Save actor to the database (assuming your _service handles async)
            await _service.UpdateAsync(id, cinema);  // Ensure this is awaited

            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("Error")]
        public async Task<IActionResult> Error()
        {
            return View("Error!");
        }
    }
}