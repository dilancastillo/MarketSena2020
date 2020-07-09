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
    public class EmpresasController : Controller
    {
        private readonly MarketSENAContext _context;

        public EmpresasController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.Empresa.Include(e => e.ModeloNegocio).Include(e => e.SectorEconomico);
            return View(await marketSENAContext.ToListAsync());
        }

        public async Task<IActionResult> Conformacion()
        {
            var marketSENAContext = _context.Empresa.Include(e => e.ModeloNegocio).Include(e => e.SectorEconomico);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.ModeloNegocio)
                .Include(e => e.SectorEconomico)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["ModeloNegocioID"] = new SelectList(_context.Set<ModeloNegocio>(), "ModeloNegocioID", "Nombre");
            ViewData["SectorEconomicoID"] = new SelectList(_context.Set<SectorEconomico>(), "SectorEconomicoID", "CiiuSeccionID");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,ModeloNegocioID,SectorEconomicoID,RazonSocial,Nit")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Conformacion", "Empresas", new { area = "" });
            }
            ViewData["ModeloNegocioID"] = new SelectList(_context.Set<ModeloNegocio>(), "ModeloNegocioID", "Nombre", empresa.ModeloNegocioID);
            ViewData["SectorEconomicoID"] = new SelectList(_context.Set<SectorEconomico>(), "SectorEconomicoID", "CiiuSeccionID", empresa.SectorEconomicoID);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["ModeloNegocioID"] = new SelectList(_context.Set<ModeloNegocio>(), "ModeloNegocioID", "ModeloNegocioID", empresa.ModeloNegocioID);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpresaID,ModeloNegocioID,SectorEconomicoID,RazonSocial,Nit")] Empresa empresa)
        {
            if (id != empresa.EmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.EmpresaID))
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
            ViewData["ModeloNegocioID"] = new SelectList(_context.Set<ModeloNegocio>(), "ModeloNegocioID", "ModeloNegocioID", empresa.ModeloNegocioID);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .Include(e => e.ModeloNegocio)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.EmpresaID == id);
        }
    }
}
