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
    public class TipoRolesController : Controller
    {
        private readonly MarketSENAContext _context;

        public TipoRolesController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: TipoRoles
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.TipoRol.Include(t => t.Rol).Include(t => t.Usuario);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: TipoRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRol
                .Include(t => t.Rol)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.TipoRolID == id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return View(tipoRol);
        }

        // GET: TipoRoles/Create
        public IActionResult Create()
        {
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "RolID");
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "UsuarioID", "Contrasenia");
            return View();
        }

        // POST: TipoRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoRolID,RolID,UsuarioID,FechaInicio")] TipoRol tipoRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "RolID", tipoRol.RolID);
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "UsuarioID", "Contrasenia", tipoRol.UsuarioID);
            return View(tipoRol);
        }

        // GET: TipoRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRol.FindAsync(id);
            if (tipoRol == null)
            {
                return NotFound();
            }
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "RolID", tipoRol.RolID);
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "UsuarioID", "Contrasenia", tipoRol.UsuarioID);
            return View(tipoRol);
        }

        // POST: TipoRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoRolID,RolID,UsuarioID,FechaInicio")] TipoRol tipoRol)
        {
            if (id != tipoRol.TipoRolID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRolExists(tipoRol.TipoRolID))
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
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "RolID", tipoRol.RolID);
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "UsuarioID", "Contrasenia", tipoRol.UsuarioID);
            return View(tipoRol);
        }

        // GET: TipoRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRol
                .Include(t => t.Rol)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.TipoRolID == id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return View(tipoRol);
        }

        // POST: TipoRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoRol = await _context.TipoRol.FindAsync(id);
            _context.TipoRol.Remove(tipoRol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRolExists(int id)
        {
            return _context.TipoRol.Any(e => e.TipoRolID == id);
        }
    }
}
