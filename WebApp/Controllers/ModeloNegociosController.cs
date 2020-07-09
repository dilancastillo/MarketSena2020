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
    public class ModeloNegociosController : Controller
    {
        private readonly MarketSENAContext _context;

        public ModeloNegociosController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: ModeloNegocios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModeloNegocio.ToListAsync());
        }

        // GET: ModeloNegocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloNegocio = await _context.ModeloNegocio
                .FirstOrDefaultAsync(m => m.ModeloNegocioID == id);
            if (modeloNegocio == null)
            {
                return NotFound();
            }

            return View(modeloNegocio);
        }

        // GET: ModeloNegocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeloNegocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeloNegocioID,Nombre,Descripcion")] ModeloNegocio modeloNegocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloNegocio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Empresas", new { area = "" } );
            }
            return View(modeloNegocio);
        }

        // GET: ModeloNegocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloNegocio = await _context.ModeloNegocio.FindAsync(id);
            if (modeloNegocio == null)
            {
                return NotFound();
            }
            return View(modeloNegocio);
        }

        // POST: ModeloNegocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModeloNegocioID,Nombre,Descripcion")] ModeloNegocio modeloNegocio)
        {
            if (id != modeloNegocio.ModeloNegocioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloNegocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloNegocioExists(modeloNegocio.ModeloNegocioID))
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
            return View(modeloNegocio);
        }

        // GET: ModeloNegocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloNegocio = await _context.ModeloNegocio
                .FirstOrDefaultAsync(m => m.ModeloNegocioID == id);
            if (modeloNegocio == null)
            {
                return NotFound();
            }

            return View(modeloNegocio);
        }

        // POST: ModeloNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloNegocio = await _context.ModeloNegocio.FindAsync(id);
            _context.ModeloNegocio.Remove(modeloNegocio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloNegocioExists(int id)
        {
            return _context.ModeloNegocio.Any(e => e.ModeloNegocioID == id);
        }
    }
}
