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
    public class PlantillasController : Controller
    {
        private readonly MarketSENAContext _context;

        public PlantillasController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: Plantillas
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }

        public async Task<IActionResult> Empacados()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Panaderia()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Industrial()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Ropa()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Restaurante()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Corretaje()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Publicitario()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }
        public async Task<IActionResult> Prueba()
        {
            var marketSENAContext = _context.Plantilla.Include(p => p.ModeloNegocio);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: Plantillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantilla = await _context.Plantilla
                .Include(p => p.ModeloNegocio)
                .FirstOrDefaultAsync(m => m.PlantillaID == id);
            if (plantilla == null)
            {
                return NotFound();
            }

            return View(plantilla);
        }

        // GET: Plantillas/Create
        public IActionResult Create()
        {
            ViewData["ModeloNegocioID"] = new SelectList(_context.ModeloNegocio, "ModeloNegocioID", "ModeloNegocioID");
            return View();
        }

        // POST: Plantillas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantillaID,ModeloNegocioID,Fecha,Visible")] Plantilla plantilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeloNegocioID"] = new SelectList(_context.ModeloNegocio, "ModeloNegocioID", "ModeloNegocioID", plantilla.ModeloNegocioID);
            return View(plantilla);
        }

        // GET: Plantillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantilla = await _context.Plantilla.FindAsync(id);
            if (plantilla == null)
            {
                return NotFound();
            }
            ViewData["ModeloNegocioID"] = new SelectList(_context.ModeloNegocio, "ModeloNegocioID", "ModeloNegocioID", plantilla.ModeloNegocioID);
            return View(plantilla);
        }

        // POST: Plantillas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantillaID,ModeloNegocioID,Fecha,Visible")] Plantilla plantilla)
        {
            if (id != plantilla.PlantillaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantillaExists(plantilla.PlantillaID))
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
            ViewData["ModeloNegocioID"] = new SelectList(_context.ModeloNegocio, "ModeloNegocioID", "ModeloNegocioID", plantilla.ModeloNegocioID);
            return View(plantilla);
        }

        // GET: Plantillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantilla = await _context.Plantilla
                .Include(p => p.ModeloNegocio)
                .FirstOrDefaultAsync(m => m.PlantillaID == id);
            if (plantilla == null)
            {
                return NotFound();
            }

            return View(plantilla);
        }

        // POST: Plantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantilla = await _context.Plantilla.FindAsync(id);
            _context.Plantilla.Remove(plantilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantillaExists(int id)
        {
            return _context.Plantilla.Any(e => e.PlantillaID == id);
        }
    }
}
