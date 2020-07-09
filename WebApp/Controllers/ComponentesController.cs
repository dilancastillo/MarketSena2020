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
    public class ComponentesController : Controller
    {
        private readonly MarketSENAContext _context;

        public ComponentesController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: Componentes
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.Componente.Include(c => c.Seccion);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: Componentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .Include(c => c.Seccion)
                .FirstOrDefaultAsync(m => m.ComponenteID == id);
            if (componente == null)
            {
                return NotFound();
            }

            return View(componente);
        }

        // GET: Componentes/Create
        public IActionResult Create()
        {
            ViewData["SeccionID"] = new SelectList(_context.Set<Seccion>(), "SeccionID", "SeccionID");
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComponenteID,SeccionID,Descripcion,Tipo,Visible")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeccionID"] = new SelectList(_context.Set<Seccion>(), "SeccionID", "SeccionID", componente.SeccionID);
            return View(componente);
        }

        // GET: Componentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente.FindAsync(id);
            if (componente == null)
            {
                return NotFound();
            }
            ViewData["SeccionID"] = new SelectList(_context.Set<Seccion>(), "SeccionID", "SeccionID", componente.SeccionID);
            return View(componente);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComponenteID,SeccionID,Descripcion,Tipo,Visible")] Componente componente)
        {
            if (id != componente.ComponenteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponenteExists(componente.ComponenteID))
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
            ViewData["SeccionID"] = new SelectList(_context.Set<Seccion>(), "SeccionID", "SeccionID", componente.SeccionID);
            return View(componente);
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .Include(c => c.Seccion)
                .FirstOrDefaultAsync(m => m.ComponenteID == id);
            if (componente == null)
            {
                return NotFound();
            }

            return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componente = await _context.Componente.FindAsync(id);
            _context.Componente.Remove(componente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponenteExists(int id)
        {
            return _context.Componente.Any(e => e.ComponenteID == id);
        }
    }
}
