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

        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [Route("Create")]
        public async Task<IActionResult> Create(int id)
        {

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(producer);  // If invalid, return the same view with errors
            }

            // Save actor to the database (assuming your _service handles async)
            await _service.AddAsync(producer);  // Ensure this is awaited

            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));
        }


        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(producer);  // If invalid, return the same view with errors
            }
            if (id == producer.Id)
            {
                // Save actor to the database (assuming your _service handles async)
                await _service.UpdateAsync(id, producer);  // Ensure this is awaited

                // Redirect to the Index page (list of actors) after successful creation
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
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