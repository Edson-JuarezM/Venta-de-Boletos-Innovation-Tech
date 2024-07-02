using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperChampiniones.Models;
using SuperChampiniones.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperChampiniones.Controllers
{
    public class VentasController : Controller
    {
        private readonly MyContext _context;

        public VentasController(MyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Reporte()
        {
            var ventas = await _context.Ventas.ToListAsync();

            var reporteData = ventas
                .GroupBy(v => new { v.Fecha.Value.Month, v.Fecha.Value.Year })
                .Select(g => new ReporteViewModel
                {
                    Mes = g.Key.Month,
                    Ventas = g.Count(),
                    Total = g.Sum(v => v.Sector.HasValue ? SectorPrices[v.Sector.Value] : 0)
                })
                .ToList();

            return View(reporteData);
        }
        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var ventas = _context.Ventas
                                 .Include(v => v.Miembro_Vip)
                                 .Include(v => v.Usuario)
                                 .Include(v => v.Partido)
                                 .ToList();
            return View(ventas);
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var venta = await _context.Ventas
                                  .Include(v => v.Miembro_Vip)
                                  .Include(v => v.Usuario)
                                  .Include(v => v.Partido)
                                  .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        public static Dictionary<SectorEnum, int> SectorPrices = new Dictionary<SectorEnum, int>
        {
            { SectorEnum.Preferencia, 100 },
            { SectorEnum.General, 60 },
            { SectorEnum.CurvaNorte, 50 },
            { SectorEnum.CurvaSur, 30 }
        };

        // GET: Ventas/Create
        public IActionResult Create()
        {
            var partidos = _context.Partido
                .Select(p => new { p.Id, NombrePartido = $"{p.EquipoA} vs {p.EquipoB}" })
                .ToList();

            ViewData["PartidoId"] = new SelectList(partidos, "Id", "NombrePartido");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            ViewData["MiembroVipId"] = new SelectList(_context.Miembro_Vip, "Id", "Ci");
            ViewData["Sector"] = new SelectList(
                Enum.GetValues(typeof(SectorEnum)).Cast<SectorEnum>().Select(
                    s => new { ID = s, Name = $"{s} - {SectorPrices[s]} Bs" }
                ),
                "ID",
                "Name"
            );

            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NroRecibo,Sector,Fecha,UsuarioId,Miembro_VipId,PartidoId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                venta.NroRecibo = GetNumero();

                try
                {
                    _context.Add(venta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error al guardar los cambios: {ex.Message} \n {ex.InnerException?.Message}");
                }
            }

            var partidos = _context.Partido
                .Select(p => new { p.Id, NombrePartido = $"{p.EquipoA} vs {p.EquipoB}" })
                .ToList();

            ViewData["PartidoId"] = new SelectList(partidos, "Id", "NombrePartido", venta.PartidoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", venta.UsuarioId);
            ViewData["MiembroVipId"] = new SelectList(_context.Miembro_Vip, "Id", "Ci", venta.Miembro_VipId);
            ViewData["Sector"] = new SelectList(
                Enum.GetValues(typeof(SectorEnum)).Cast<SectorEnum>().Select(
                    s => new { ID = s, Name = $"{s} - {SectorPrices[s]} Bs" }
                ),
                "ID",
                "Name",
                venta.Sector
            );

            return View(venta);
        }
        private int GetNumero()
        {
            if (_context.Ventas.Any())
            {
                return _context.Ventas.Max(i => i.NroRecibo) + 1;
            }
            return 1;
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.Partido)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
