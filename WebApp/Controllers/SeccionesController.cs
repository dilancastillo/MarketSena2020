using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketSENA.Data;
using MarketSENA.Models;

namespace MarketSENA.Controllers
{
    public class SeccionesController : Controller
    {
        private readonly MarketSENAContext _context;

        public SeccionesController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: Secciones
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.Seccion.Include(s => s.Plantilla);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: Secciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seccion = await _context.Seccion
                .Include(s => s.Plantilla)
                .FirstOrDefaultAsync(m => m.SeccionID == id);
            if (seccion == null)
            {
                return NotFound();
            }

            return View(seccion);
        }

        // GET: Secciones/Create
        public IActionResult Create()
        {
            ViewData["PlantillaID"] = new SelectList(_context.Plantilla, "PlantillaID", "PlantillaID");
            return View();
        }

        // POST: Secciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeccionID,PlantillaID,Visible")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantillaID"] = new SelectList(_context.Plantilla, "PlantillaID", "PlantillaID", seccion.PlantillaID);
            return View(seccion);
        }

        // GET: Secciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seccion = await _context.Seccion.FindAsync(id);
            if (seccion == null)
            {
                return NotFound();
            }
            ViewData["PlantillaID"] = new SelectList(_context.Plantilla, "PlantillaID", "PlantillaID", seccion.PlantillaID);
            return View(seccion);
        }

        // POST: Secciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeccionID,PlantillaID,Visible")] Seccion seccion)
        {
            if (id != seccion.SeccionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeccionExists(seccion.SeccionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantillaID"] = new SelectList(_context.Plantilla, "PlantillaID", "PlantillaID", seccion.PlantillaID);
            return View(seccion);
        }

        // GET: Secciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seccion = await _context.Seccion
                .Include(s => s.Plantilla)
                .FirstOrDefaultAsync(m => m.SeccionID == id);
            if (seccion == null)
            {
                return NotFound();
            }

            return View(seccion);
        }

        // POST: Secciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seccion = await _context.Seccion.FindAsync(id);
            _context.Seccion.Remove(seccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeccionExists(int id)
        {
            return _context.Seccion.Any(e => e.SeccionID == id);
        }
    }
}
