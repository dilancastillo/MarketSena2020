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
    public class CiiuDivisionesController : Controller
    {
        private readonly MarketSENAContext _context;

        public CiiuDivisionesController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: CiiuDivisiones
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.CiiuDivision.Include(c => c.CiiuSeccion);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: CiiuDivisiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuDivision = await _context.CiiuDivision
                .Include(c => c.CiiuSeccion)
                .FirstOrDefaultAsync(m => m.CiiuDivisionID == id);
            if (ciiuDivision == null)
            {
                return NotFound();
            }

            return View(ciiuDivision);
        }

        // GET: CiiuDivisiones/Create
        public IActionResult Create()
        {
            ViewData["CiiuSeccionID"] = new SelectList(_context.Set<CiiuSeccion>(), "CiiuSeccionID", "Descripcion");
            return View();
        }

        // POST: CiiuDivisiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiiuDivisionID,CiiuSeccionID,Descripcion,Codigo")] CiiuDivision ciiuDivision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciiuDivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiiuSeccionID"] = new SelectList(_context.Set<CiiuSeccion>(), "CiiuSeccionID", "Descripcion", ciiuDivision.CiiuSeccionID);
            return View(ciiuDivision);
        }

        // GET: CiiuDivisiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuDivision = await _context.CiiuDivision.FindAsync(id);
            if (ciiuDivision == null)
            {
                return NotFound();
            }
            ViewData["CiiuSeccionID"] = new SelectList(_context.Set<CiiuSeccion>(), "CiiuSeccionID", "CiiuSeccionID", ciiuDivision.CiiuSeccionID);
            return View(ciiuDivision);
        }

        // POST: CiiuDivisiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiiuDivisionID,CiiuSeccionID,Descripcion,Codigo")] CiiuDivision ciiuDivision)
        {
            if (id != ciiuDivision.CiiuDivisionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciiuDivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiiuDivisionExists(ciiuDivision.CiiuDivisionID))
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
            ViewData["CiiuSeccionID"] = new SelectList(_context.Set<CiiuSeccion>(), "CiiuSeccionID", "CiiuSeccionID", ciiuDivision.CiiuSeccionID);
            return View(ciiuDivision);
        }

        // GET: CiiuDivisiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuDivision = await _context.CiiuDivision
                .Include(c => c.CiiuSeccion)
                .FirstOrDefaultAsync(m => m.CiiuDivisionID == id);
            if (ciiuDivision == null)
            {
                return NotFound();
            }

            return View(ciiuDivision);
        }

        // POST: CiiuDivisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciiuDivision = await _context.CiiuDivision.FindAsync(id);
            _context.CiiuDivision.Remove(ciiuDivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiiuDivisionExists(int id)
        {
            return _context.CiiuDivision.Any(e => e.CiiuDivisionID == id);
        }
    }
}
