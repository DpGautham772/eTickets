using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Services;
using eTickets.Models;
using eTickets.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eTickets.Controllers
{
    [Route("Actors")]
    public class ActorsController : Controller
    {
        private readonly ILogger<ActorsController> _logger;
        private readonly IActorsService _service;

        public ActorsController(IActorsService service, ILogger<ActorsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        // public ActorsController(ILogger<ActorsController> logger)
        // {
        //     _logger = logger;
        // }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }



        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(actor);  // If invalid, return the same view with errors
            }

            // Save actor to the database (assuming your _service handles async)
            await _service.AddAsync(actor);  // Ensure this is awaited

            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) { return View("NotFound"); }
            return View(actorDetails);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(actor);
            }


            // Save actor to the database (assuming your _service handles async)
            await _service.UpdateAsync(id, actor);  // Ensure this is awaited

            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));

            // If invalid, return the same view with errors


        }


        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);


            // Redirect to the Index page (list of actors) after successful creation
            return RedirectToAction(nameof(Index));

            // If invalid, return the same view with errors


        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }

        //Get: Actors/Create

    }
}