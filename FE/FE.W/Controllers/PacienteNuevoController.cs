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
    public class PacienteNuevoController : Controller
    {
        private readonly DBDentistaContext _context;

        public PacienteNuevoController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: PacienteNuevo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PacienteNuevo.ToListAsync());
        }

        // GET: PacienteNuevo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteNuevo = await _context.PacienteNuevo
                .FirstOrDefaultAsync(m => m.IdPacienteNuevo == id);
            if (pacienteNuevo == null)
            {
                return NotFound();
            }

            return View(pacienteNuevo);
        }

        // GET: PacienteNuevo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacienteNuevo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPacienteNuevo,NombrePacienteNuevo,ApellidoPacienteNuevo,Contraseña")] PacienteNuevo pacienteNuevo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteNuevo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteNuevo);
        }

        // GET: PacienteNuevo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteNuevo = await _context.PacienteNuevo.FindAsync(id);
            if (pacienteNuevo == null)
            {
                return NotFound();
            }
            return View(pacienteNuevo);
        }

        // POST: PacienteNuevo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPacienteNuevo,NombrePacienteNuevo,ApellidoPacienteNuevo,Contraseña")] PacienteNuevo pacienteNuevo)
        {
            if (id != pacienteNuevo.IdPacienteNuevo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteNuevo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteNuevoExists(pacienteNuevo.IdPacienteNuevo))
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
            return View(pacienteNuevo);
        }

        // GET: PacienteNuevo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteNuevo = await _context.PacienteNuevo
                .FirstOrDefaultAsync(m => m.IdPacienteNuevo == id);
            if (pacienteNuevo == null)
            {
                return NotFound();
            }

            return View(pacienteNuevo);
        }

        // POST: PacienteNuevo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacienteNuevo = await _context.PacienteNuevo.FindAsync(id);
            _context.PacienteNuevo.Remove(pacienteNuevo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteNuevoExists(int id)
        {
            return _context.PacienteNuevo.Any(e => e.IdPacienteNuevo == id);
        }
    }
}
