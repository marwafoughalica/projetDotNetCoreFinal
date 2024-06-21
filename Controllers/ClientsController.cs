

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
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public IActionResult Index()
        {
            var clients = _context.client.ToList();
            return View(clients);
        }


        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.client
                .FirstOrDefaultAsync(m => m.IdCl == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client )
        {
            _context.client.Add(client);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Clients/Edit/5

        public IActionResult Edit(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.client.Find(id);
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            _context.client.Update(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Clients/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) NotFound();
            var cat = _context.client.Find(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult Delete2(int? IdCl)
        {
            if (IdCl == null) NotFound();
            var clt = _context.client.Find(IdCl);
            _context.client.Remove(clt);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private bool ClientExists(int id)
        {
            return _context.client.Any(e => e.IdCl == id);
        }
    }
}
