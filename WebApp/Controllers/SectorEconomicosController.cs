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
    public class SectorEconomicosController : Controller
    {
        private readonly MarketSENAContext _context;

        public SectorEconomicosController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: SectorEconomicos
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.SectorEconomico.Include(s => s.CiiuSeccion);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: SectorEconomicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorEconomico = await _context.SectorEconomico
                .Include(s => s.CiiuSeccion)
                .FirstOrDefaultAsync(m => m.SectorEconomicoID == id);
            if (sectorEconomico == null)
            {
                return NotFound();
            }

            return View(sectorEconomico);
        }

        // GET: SectorEconomicos/Create
        public IActionResult Create()
        {
            ViewData["CiiuSeccionID"] = new SelectList(_context.Set<CiiuSeccion>(), "CiiuSeccionID", "Descripcion");
            return View();
        }

        // POST: SectorEconomicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectorEconomicoID,CiiuSeccionID,Codigo,Tipo")] SectorEconomico sectorEconomico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectorEconomico);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "ModeloNegocios", new { area = "" });
            }
            ViewData["CiiuSeccionID"] = new SelectList(_context.Set<CiiuSeccion>(), "CiiuSeccionID", "Descripcion", sectorEconomico.CiiuSeccionID);
            return View(sectorEconomico);
        }

        // GET: SectorEconomicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorEconomico = await _context.SectorEconomico.FindAsync(id);
            if (sectorEconomico == null)
            {
                return NotFound();
            }
            ViewData["CiiuSeccionID"] = new SelectList(_context.CiiuSeccion, "CiiuSeccionID", "CiiuSeccionID", sectorEconomico.CiiuSeccionID);
            return View(sectorEconomico);
        }

        // POST: SectorEconomicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectorEconomicoID,CiiuSeccionID,Codigo,Tipo")] SectorEconomico sectorEconomico)
        {
            if (id != sectorEconomico.SectorEconomicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectorEconomico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorEconomicoExists(sectorEconomico.SectorEconomicoID))
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
            ViewData["CiiuSeccionID"] = new SelectList(_context.CiiuSeccion, "CiiuSeccionID", "CiiuSeccionID", sectorEconomico.CiiuSeccionID);
            return View(sectorEconomico);
        }

        // GET: SectorEconomicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorEconomico = await _context.SectorEconomico
                .Include(s => s.CiiuSeccion)
                .FirstOrDefaultAsync(m => m.SectorEconomicoID == id);
            if (sectorEconomico == null)
            {
                return NotFound();
            }

            return View(sectorEconomico);
        }

        // POST: SectorEconomicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectorEconomico = await _context.SectorEconomico.FindAsync(id);
            _context.SectorEconomico.Remove(sectorEconomico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorEconomicoExists(int id)
        {
            return _context.SectorEconomico.Any(e => e.SectorEconomicoID == id);
        }
    }
}
