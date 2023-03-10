#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;
using AppCore.Results.Bases;
using DataAccess.Enum;
using Microsoft.AspNetCore.Authorization;

//Generated by ScaffoldApp.
namespace MusicSchool.Controllers
{
    public class InstrumentsController : Controller
    {
        // Add service injections here
        private readonly IInstrumentService _instrumentService;

        public InstrumentsController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }

        // GET: Instruments
        public IActionResult Index()
        {
            var instruments = _instrumentService.Query().ToList();
            return View(instruments);
        }

        // GET: Instruments/Details/5
        public IActionResult Details(int id)
        {
            InstrumentModel instrument = _instrumentService.Query().SingleOrDefault(i => i.Id == id); ; // TODO: Add get item service logic here
            if (instrument == null)
            {
                return View("_Error", "Intrument cannot be found!");
            }
            return View(instrument);
        }

        // GET: Instruments/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InstrumentModel instrument)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                Result result = _instrumentService.Add(instrument);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ViewData["Message"] = result.Message;
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(instrument);
        }

        // GET: Instruments/Edit/5
        public IActionResult Edit(int id)
        {
            InstrumentModel instrument = _instrumentService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (instrument == null)
            {
                return View("_Error", "Intrument cannot be found!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(instrument);
        }

        // POST: Instruments/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InstrumentModel instrument)
        {
            if (ModelState.IsValid)
            {
                var result = _instrumentService.Update(instrument);

                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // success
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message); // error
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(instrument);
        }

        // GET: Instruments/Delete/5
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            InstrumentModel instrument = _instrumentService.Query().SingleOrDefault(s => s.Id == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // POST: Instruments/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _instrumentService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
