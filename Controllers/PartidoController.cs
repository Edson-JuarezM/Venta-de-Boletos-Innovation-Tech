using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using SuperChampiniones.Contexto;
using SuperChampiniones.Models;

namespace SuperChampiniones.Controllers
{
    public class PartidoController : Controller
    {
        private readonly MyContext _context;
        IWebHostEnvironment _webHostEnvironment;

        public PartidoController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; ;
        }

        // GET: Partido
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partido.ToListAsync());
        }

        // GET: Partido/Details/5
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

        // GET: Partido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipoA,EquipoB,Fecha_Hora,EscudoFile1,EscudoFile2")] Partido partido)
        {


            if (partido.EscudoFile1 != null && partido.EscudoFile2 != null)
            {
                await GuardarImagen(partido);
            }

            if (ModelState.IsValid)
            {
                _context.Add(partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partido);
        }

        // GET: Partido/Edit/5
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

        // POST: Partido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipoA,EquipoB,Fecha_Hora,EscudoFile1,EscudoFile2")] Partido partido)
        {
            if (id != partido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (partido.EscudoFile1!= null && partido.EscudoFile2!=null) {
                        await GuardarImagen(partido);
                    }
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

        private async Task GuardarImagen(Partido partido)
        {
            if (partido.EscudoFile1 == null || partido.EscudoFile2 == null)
            {
                throw new ArgumentNullException("Los archivos de imagen no pueden ser nulos.");
            }

            // Formar el nombre de la foto
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string extension1 = Path.GetExtension(partido.EscudoFile1.FileName);
            string extension2 = Path.GetExtension(partido.EscudoFile2.FileName);
            string nameFoto1 = $"{partido.Id}_{partido.EquipoA}{extension1}";
            string nameFoto2 = $"{partido.Id}_{partido.EquipoB}{extension2}";

            partido.UrlEscudoA = nameFoto1;
            partido.UrlEscudoB = nameFoto2;

            // Ruta donde se guardarán las imágenes
            string path1 = Path.Combine(wwwRootPath, "escudos", nameFoto1);
            string path2 = Path.Combine(wwwRootPath, "escudos", nameFoto2);

            // Copiar las fotos en el proyecto
            using (var fileStream1 = new FileStream(path1, FileMode.Create))
            {
                await partido.EscudoFile1.CopyToAsync(fileStream1);
            }

            using (var fileStream2 = new FileStream(path2, FileMode.Create))
            {
                await partido.EscudoFile2.CopyToAsync(fileStream2);
            }
        }




        // GET: Partido/Delete/5
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

        // POST: Partido/Delete/5
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
