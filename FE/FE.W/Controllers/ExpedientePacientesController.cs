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
    public class ExpedientePacientesController : Controller
    {
        private readonly DBDentistaContext _context;

        public ExpedientePacientesController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: ExpedientePacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpedientePaciente.ToListAsync());
        }

        // GET: ExpedientePacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientePaciente = await _context.ExpedientePaciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (expedientePaciente == null)
            {
                return NotFound();
            }

            return View(expedientePaciente);
        }

        // GET: ExpedientePacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpedientePacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Cedula,NombrePaciente,ApellidoPaciente,FechaNacimiento,Edad,Padecimientos")] ExpedientePaciente expedientePaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expedientePaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expedientePaciente);
        }

        // GET: ExpedientePacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientePaciente = await _context.ExpedientePaciente.FindAsync(id);
            if (expedientePaciente == null)
            {
                return NotFound();
            }
            return View(expedientePaciente);
        }

        // POST: ExpedientePacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Cedula,NombrePaciente,ApellidoPaciente,FechaNacimiento,Edad,Padecimientos")] ExpedientePaciente expedientePaciente)
        {
            if (id != expedientePaciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expedientePaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedientePacienteExists(expedientePaciente.IdPaciente))
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
            return View(expedientePaciente);
        }

        // GET: ExpedientePacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientePaciente = await _context.ExpedientePaciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (expedientePaciente == null)
            {
                return NotFound();
            }

            return View(expedientePaciente);
        }

        // POST: ExpedientePacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expedientePaciente = await _context.ExpedientePaciente.FindAsync(id);
            _context.ExpedientePaciente.Remove(expedientePaciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedientePacienteExists(int id)
        {
            return _context.ExpedientePaciente.Any(e => e.IdPaciente == id);
        }
    }
}
