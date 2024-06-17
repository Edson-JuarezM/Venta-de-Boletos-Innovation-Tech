using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperChampiniones.Contexto;
using SuperChampiniones.Models;

namespace SuperChampiniones.Controllers
{
    public class PartidoesController : Controller
    {
        private readonly MyContext _context;

        public PartidoesController(MyContext context)
        {
            _context = context;
        }

        // GET: Partidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partido.ToListAsync());
        }

        // GET: Partidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // GET: Partidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipoA,EquipoB,Fecha_Hora,UrlEscudA,UrlEscudB")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partido);
        }

        // GET: Partidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido.FindAsync(id);
            if (partido == null)
            {
                return NotFound();
            }
            return View(partido);
        }

        // POST: Partidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipoA,EquipoB,Fecha_Hora,UrlEscudA,UrlEscudB")] Partido partido)
        {
            if (id != partido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidoExists(partido.Id))
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
            return View(partido);
        }

        // GET: Partidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // POST: Partidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partido = await _context.Partido.FindAsync(id);
            if (partido != null)
            {
                _context.Partido.Remove(partido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidoExists(int id)
        {
            return _context.Partido.Any(e => e.Id == id);
        }
    }
}
