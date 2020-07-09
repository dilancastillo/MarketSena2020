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
    public class CiiuGruposController : Controller
    {
        private readonly MarketSENAContext _context;

        public CiiuGruposController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: CiiuGrupos
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.CiiuGrupo.Include(c => c.CiiuDivision);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: CiiuGrupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuGrupo = await _context.CiiuGrupo
                .Include(c => c.CiiuDivision)
                .FirstOrDefaultAsync(m => m.CiiuGrupoID == id);
            if (ciiuGrupo == null)
            {
                return NotFound();
            }

            return View(ciiuGrupo);
        }

        // GET: CiiuGrupos/Create
        public IActionResult Create()
        {
            ViewData["CiiuDivisionID"] = new SelectList(_context.CiiuDivision, "CiiuDivisionID", "Descripcion");
            return View();
        }

        // POST: CiiuGrupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiiuGrupoID,CiiuDivisionID,Descripcion,Codigo")] CiiuGrupo ciiuGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciiuGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiiuDivisionID"] = new SelectList(_context.CiiuDivision, "CiiuDivisionID", "Descripcion", ciiuGrupo.CiiuDivisionID);
            return View(ciiuGrupo);
        }

        // GET: CiiuGrupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuGrupo = await _context.CiiuGrupo.FindAsync(id);
            if (ciiuGrupo == null)
            {
                return NotFound();
            }
            ViewData["CiiuDivisionID"] = new SelectList(_context.CiiuDivision, "CiiuDivisionID", "CiiuDivisionID", ciiuGrupo.CiiuDivisionID);
            return View(ciiuGrupo);
        }

        // POST: CiiuGrupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiiuGrupoID,CiiuDivisionID,Descripcion,Codigo")] CiiuGrupo ciiuGrupo)
        {
            if (id != ciiuGrupo.CiiuGrupoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciiuGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiiuGrupoExists(ciiuGrupo.CiiuGrupoID))
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
            ViewData["CiiuDivisionID"] = new SelectList(_context.CiiuDivision, "CiiuDivisionID", "CiiuDivisionID", ciiuGrupo.CiiuDivisionID);
            return View(ciiuGrupo);
        }

        // GET: CiiuGrupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuGrupo = await _context.CiiuGrupo
                .Include(c => c.CiiuDivision)
                .FirstOrDefaultAsync(m => m.CiiuGrupoID == id);
            if (ciiuGrupo == null)
            {
                return NotFound();
            }

            return View(ciiuGrupo);
        }

        // POST: CiiuGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciiuGrupo = await _context.CiiuGrupo.FindAsync(id);
            _context.CiiuGrupo.Remove(ciiuGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiiuGrupoExists(int id)
        {
            return _context.CiiuGrupo.Any(e => e.CiiuGrupoID == id);
        }
    }
}
