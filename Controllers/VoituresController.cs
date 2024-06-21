

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
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voitures

      
        public IActionResult Index()
        {
            var voitures = _context.voiture.ToList();
            ViewBag.Voitures = voitures;
            return View(voitures);
        }


        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _context.voiture
                .FirstOrDefaultAsync(m => m.IdVoi == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voitures/Create
 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Voiture voiture)
        {
            _context.voiture.Add(voiture);

            _context.SaveChanges();
        
            return RedirectToAction("Index");
        }

        // GET: Voitures/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.voiture.Find(id);
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Voiture voi)

        {
            _context.voiture.Update(voi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Voitures/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.voiture.Find(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult Delete2(int? IdVoi)
        {
            if (IdVoi == null) NotFound();
            var voiture = _context.voiture.Find(IdVoi);
            _context.voiture.Remove(voiture);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // POST: Voitures/Delete/5


        private bool VoitureExists(int id)
        {
            return _context.voiture.Any(e => e.IdVoi == id);
        }
    }
}
