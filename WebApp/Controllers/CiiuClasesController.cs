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
    public class CiiuClasesController : Controller
    {
        private readonly MarketSENAContext _context;

        public CiiuClasesController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: CiiuClases
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.CiiuClase.Include(c => c.CiiuGrupo);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: CiiuClases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuClase = await _context.CiiuClase
                .Include(c => c.CiiuGrupo)
                .FirstOrDefaultAsync(m => m.CiiuClaseID == id);
            if (ciiuClase == null)
            {
                return NotFound();
            }

            return View(ciiuClase);
        }

        // GET: CiiuClases/Create
        public IActionResult Create()
        {
            ViewData["CiiuGrupoID"] = new SelectList(_context.Set<CiiuGrupo>(), "CiiuGrupoID", "Descripcion");
            return View();
        }

        // POST: CiiuClases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiiuClaseID,CiiuGrupoID,Descripcion,Codigo")] CiiuClase ciiuClase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciiuClase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiiuGrupoID"] = new SelectList(_context.Set<CiiuGrupo>(), "CiiuGrupoID", "Descripcion", ciiuClase.CiiuGrupoID);
            return View(ciiuClase);
        }

        // GET: CiiuClases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuClase = await _context.CiiuClase.FindAsync(id);
            if (ciiuClase == null)
            {
                return NotFound();
            }
            ViewData["CiiuGrupoID"] = new SelectList(_context.Set<CiiuGrupo>(), "CiiuGrupoID", "CiiuGrupoID", ciiuClase.CiiuGrupoID);
            return View(ciiuClase);
        }

        // POST: CiiuClases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiiuClaseID,CiiuGrupoID,Descripcion,Codigo")] CiiuClase ciiuClase)
        {
            if (id != ciiuClase.CiiuClaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciiuClase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiiuClaseExists(ciiuClase.CiiuClaseID))
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
            ViewData["CiiuGrupoID"] = new SelectList(_context.Set<CiiuGrupo>(), "CiiuGrupoID", "CiiuGrupoID", ciiuClase.CiiuGrupoID);
            return View(ciiuClase);
        }

        // GET: CiiuClases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuClase = await _context.CiiuClase
                .Include(c => c.CiiuGrupo)
                .FirstOrDefaultAsync(m => m.CiiuClaseID == id);
            if (ciiuClase == null)
            {
                return NotFound();
            }

            return View(ciiuClase);
        }

        // POST: CiiuClases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciiuClase = await _context.CiiuClase.FindAsync(id);
            _context.CiiuClase.Remove(ciiuClase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiiuClaseExists(int id)
        {
            return _context.CiiuClase.Any(e => e.CiiuClaseID == id);
        }
    }
}
