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
    public class UsuarioEmpresasController : Controller
    {
        private readonly MarketSENAContext _context;

        public UsuarioEmpresasController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: UsuarioEmpresas
        public async Task<IActionResult> Index()
        {
            var marketSENAContext = _context.UsuarioEmpresa.Include(u => u.Empresa).Include(u => u.Usuario);
            return View(await marketSENAContext.ToListAsync());
        }

        // GET: UsuarioEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEmpresa = await _context.UsuarioEmpresa
                .Include(u => u.Empresa)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioEmpresaID == id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresas/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresa, "EmpresaID", "EmpresaID");
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "Contrasenia");
            return View();
        }

        // POST: UsuarioEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioEmpresaID,EmpresaID,UsuarioID")] UsuarioEmpresa usuarioEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresa, "EmpresaID", "EmpresaID", usuarioEmpresa.EmpresaID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "Contrasenia", usuarioEmpresa.UsuarioID);
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEmpresa = await _context.UsuarioEmpresa.FindAsync(id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresa, "EmpresaID", "EmpresaID", usuarioEmpresa.EmpresaID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "Contrasenia", usuarioEmpresa.UsuarioID);
            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioEmpresaID,EmpresaID,UsuarioID")] UsuarioEmpresa usuarioEmpresa)
        {
            if (id != usuarioEmpresa.UsuarioEmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioEmpresaExists(usuarioEmpresa.UsuarioEmpresaID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresa, "EmpresaID", "EmpresaID", usuarioEmpresa.EmpresaID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "UsuarioID", "Contrasenia", usuarioEmpresa.UsuarioID);
            return View(usuarioEmpresa);
        }

        // GET: UsuarioEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEmpresa = await _context.UsuarioEmpresa
                .Include(u => u.Empresa)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioEmpresaID == id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return View(usuarioEmpresa);
        }

        // POST: UsuarioEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioEmpresa = await _context.UsuarioEmpresa.FindAsync(id);
            _context.UsuarioEmpresa.Remove(usuarioEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioEmpresaExists(int id)
        {
            return _context.UsuarioEmpresa.Any(e => e.UsuarioEmpresaID == id);
        }
    }
}
