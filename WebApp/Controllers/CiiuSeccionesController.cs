using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketSENA.Data;
using MarketSENA.Models;
using System.Net;
using Newtonsoft.Json;

namespace MarketSENA.Controllers
{
    public class CiiuSeccionesController : Controller
    {
        private readonly MarketSENAContext _context;

        public CiiuSeccionesController(MarketSENAContext context)
        {
            _context = context;
        }

        // GET: CiiuSecciones
        public async Task<IActionResult> Index()
        {
            //var webClient = new WebClient();
            //var json = webClient.DownloadString(@"C:\Users\PROBOOK\Documents\Visual Studio 2019\MarketSENA\WebApp\wwwroot\js\ciiu.json");
            //var ciiuLista = JsonConvert.DeserializeObject<CiiuSecciones>(json);
            return View(await _context.CiiuSeccion.ToListAsync());
        }

        // GET: CiiuSecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuSeccion = await _context.CiiuSeccion
                .FirstOrDefaultAsync(m => m.CiiuSeccionID == id);
            if (ciiuSeccion == null)
            {
                return NotFound();
            }

            return View(ciiuSeccion);
        }

        // GET: CiiuSecciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CiiuSecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiiuSeccionID,Descripcion,Codigo")] CiiuSeccion ciiuSeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciiuSeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciiuSeccion);
        }

        // GET: CiiuSecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuSeccion = await _context.CiiuSeccion.FindAsync(id);
            if (ciiuSeccion == null)
            {
                return NotFound();
            }
            return View(ciiuSeccion);
        }

        // POST: CiiuSecciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiiuSeccionID,Descripcion,Codigo")] CiiuSeccion ciiuSeccion)
        {
            if (id != ciiuSeccion.CiiuSeccionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciiuSeccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiiuSeccionExists(ciiuSeccion.CiiuSeccionID))
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
            return View(ciiuSeccion);
        }

        // GET: CiiuSecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciiuSeccion = await _context.CiiuSeccion
                .FirstOrDefaultAsync(m => m.CiiuSeccionID == id);
            if (ciiuSeccion == null)
            {
                return NotFound();
            }

            return View(ciiuSeccion);
        }

        // POST: CiiuSecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciiuSeccion = await _context.CiiuSeccion.FindAsync(id);
            _context.CiiuSeccion.Remove(ciiuSeccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiiuSeccionExists(int id)
        {
            return _context.CiiuSeccion.Any(e => e.CiiuSeccionID == id);
        }
    }
}
