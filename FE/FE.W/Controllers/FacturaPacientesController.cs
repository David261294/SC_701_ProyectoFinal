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
    public class FacturaPacientesController : Controller
    {
        private readonly DBDentistaContext _context;

        public FacturaPacientesController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: FacturaPacientes
        public async Task<IActionResult> Index()
        {
            var dBDentistaContext = _context.FacturaPaciente.Include(f => f.IdPacienteNavigation);
            return View(await dBDentistaContext.ToListAsync());
        }

        // GET: FacturaPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPaciente = await _context.FacturaPaciente
                .Include(f => f.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.CodigoFactura == id);
            if (facturaPaciente == null)
            {
                return NotFound();
            }

            return View(facturaPaciente);
        }

        // GET: FacturaPacientes/Create
        public IActionResult Create()
        {
            ViewData["IdPaciente"] = new SelectList(_context.ExpedientePaciente, "IdPaciente", "ApellidoPaciente");
            return View();
        }

        // POST: FacturaPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoFactura,IdPaciente,FechaFactura,Descuento,Iva")] FacturaPaciente facturaPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPaciente"] = new SelectList(_context.ExpedientePaciente, "IdPaciente", "ApellidoPaciente", facturaPaciente.IdPaciente);
            return View(facturaPaciente);
        }

        // GET: FacturaPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPaciente = await _context.FacturaPaciente.FindAsync(id);
            if (facturaPaciente == null)
            {
                return NotFound();
            }
            ViewData["IdPaciente"] = new SelectList(_context.ExpedientePaciente, "IdPaciente", "ApellidoPaciente", facturaPaciente.IdPaciente);
            return View(facturaPaciente);
        }

        // POST: FacturaPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoFactura,IdPaciente,FechaFactura,Descuento,Iva")] FacturaPaciente facturaPaciente)
        {
            if (id != facturaPaciente.CodigoFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaPacienteExists(facturaPaciente.CodigoFactura))
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
            ViewData["IdPaciente"] = new SelectList(_context.ExpedientePaciente, "IdPaciente", "ApellidoPaciente", facturaPaciente.IdPaciente);
            return View(facturaPaciente);
        }

        // GET: FacturaPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPaciente = await _context.FacturaPaciente
                .Include(f => f.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.CodigoFactura == id);
            if (facturaPaciente == null)
            {
                return NotFound();
            }

            return View(facturaPaciente);
        }

        // POST: FacturaPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaPaciente = await _context.FacturaPaciente.FindAsync(id);
            _context.FacturaPaciente.Remove(facturaPaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaPacienteExists(int id)
        {
            return _context.FacturaPaciente.Any(e => e.CodigoFactura == id);
        }
    }
}
