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
    public class Miembro_VipController : Controller
    {
        private readonly MyContext _context;

        public Miembro_VipController(MyContext context)
        {
            _context = context;
        }

        // GET: Miembro_Vip
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miembro_Vip.ToListAsync());
        }

        // GET: Miembro_Vip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro_Vip = await _context.Miembro_Vip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miembro_Vip == null)
            {
                return NotFound();
            }

            return View(miembro_Vip);
        }

        // GET: Miembro_Vip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miembro_Vip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ci,Celular,Saldo")] Miembro_Vip miembro_Vip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miembro_Vip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miembro_Vip);
        }

        // GET: Miembro_Vip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro_Vip = await _context.Miembro_Vip.FindAsync(id);
            if (miembro_Vip == null)
            {
                return NotFound();
            }
            return View(miembro_Vip);
        }

        // POST: Miembro_Vip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ci,Celular,Saldo")] Miembro_Vip miembro_Vip)
        {
            if (id != miembro_Vip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembro_Vip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Miembro_VipExists(miembro_Vip.Id))
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
            return View(miembro_Vip);
        }

        // GET: Miembro_Vip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro_Vip = await _context.Miembro_Vip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miembro_Vip == null)
            {
                return NotFound();
            }

            return View(miembro_Vip);
        }

        // POST: Miembro_Vip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miembro_Vip = await _context.Miembro_Vip.FindAsync(id);
            if (miembro_Vip != null)
            {
                _context.Miembro_Vip.Remove(miembro_Vip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Miembro_VipExists(int id)
        {
            return _context.Miembro_Vip.Any(e => e.Id == id);
        }
    }
}
