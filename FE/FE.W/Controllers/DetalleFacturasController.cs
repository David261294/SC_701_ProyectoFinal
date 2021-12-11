using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.W.Models;

namespace FE.W.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private readonly DBDentistaContext _context;

        public DetalleFacturasController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index()
        {
            var dBDentistaContext = _context.DetalleFactura.Include(d => d.CodigoFacturaNavigation).Include(d => d.IdProductoNavigation).Include(d => d.IdTratamientoNavigation);
            return View(await dBDentistaContext.ToListAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.CodigoFacturaNavigation)
                .Include(d => d.IdProductoNavigation)
                .Include(d => d.IdTratamientoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetalle == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["CodigoFactura"] = new SelectList(_context.FacturaPaciente, "CodigoFactura", "Descuento");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto");
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamiento, "IdTratamiento", "NombreTratamiento");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDetalle,CodigoFactura,IdTratamiento,IdProducto,Cantidad,PrecioFinal")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoFactura"] = new SelectList(_context.FacturaPaciente, "CodigoFactura", "Descuento", detalleFactura.CodigoFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", detalleFactura.IdProducto);
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamiento, "IdTratamiento", "NombreTratamiento", detalleFactura.IdTratamiento);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["CodigoFactura"] = new SelectList(_context.FacturaPaciente, "CodigoFactura", "Descuento", detalleFactura.CodigoFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", detalleFactura.IdProducto);
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamiento, "IdTratamiento", "NombreTratamiento", detalleFactura.IdTratamiento);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDetalle,CodigoFactura,IdTratamiento,IdProducto,Cantidad,PrecioFinal")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.CodigoDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.CodigoDetalle))
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
            ViewData["CodigoFactura"] = new SelectList(_context.FacturaPaciente, "CodigoFactura", "Descuento", detalleFactura.CodigoFactura);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", detalleFactura.IdProducto);
            ViewData["IdTratamiento"] = new SelectList(_context.Tratamiento, "IdTratamiento", "NombreTratamiento", detalleFactura.IdTratamiento);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.CodigoFacturaNavigation)
                .Include(d => d.IdProductoNavigation)
                .Include(d => d.IdTratamientoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetalle == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            _context.DetalleFactura.Remove(detalleFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetalleFactura.Any(e => e.CodigoDetalle == id);
        }
    }
}
