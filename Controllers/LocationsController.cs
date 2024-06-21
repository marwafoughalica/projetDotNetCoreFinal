using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mini_ProjetDonetCore.Models;

namespace Mini_ProjetDonetCore.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locations
        public IActionResult Index()
        {
            var locations = _context.location.Include(l=> l.client).Include(l=>l.Voiture).ToList();

            return View(locations);
        }


        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.location.Include(l => l.client).Include(l => l.Voiture)
                .FirstOrDefaultAsync(m => m.IdLoc == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewBag.clients = new SelectList(_context.client.ToList(), "IdCl", "name");
            ViewBag.voitures = new SelectList(_context.voiture.ToList(), "IdVoi", "matricule");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location location)
        {
            _context.location.Add(location);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Locations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.location.Find(id);

            ViewBag.clients = new SelectList(_context.client.ToList(), "IdCl", "name");
            ViewBag.voitures = new SelectList(_context.voiture.ToList(), "IdVoi", "matricule");
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Location location)

        {
            _context.location.Update(location);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Locations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.location.Find(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult Delete2(int? IdLoc)
        {
            if (IdLoc == null) NotFound();
            var loc = _context.location.Find(IdLoc);
            _context.location.Remove(loc);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool LocationExists(int id)
        {
            return _context.location.Any(e => e.IdLoc == id);
        }
    }
}
