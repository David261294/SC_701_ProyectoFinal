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
    public class ReunionController : Controller
    {
        private readonly DBDentistaContext _context;

        public ReunionController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: Reunion
        public async Task<IActionResult> Index()
        {
            var dBDentistaContext = _context.Reunion.Include(r => r.IdDentistaNavigation).Include(r => r.IdRecepcionistaNavigation);
            return View(await dBDentistaContext.ToListAsync());
        }

        // GET: Reunion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reunion = await _context.Reunion
                .Include(r => r.IdDentistaNavigation)
                .Include(r => r.IdRecepcionistaNavigation)
                .FirstOrDefaultAsync(m => m.NumeroReunion == id);
            if (reunion == null)
            {
                return NotFound();
            }

            return View(reunion);
        }

        // GET: Reunion/Create
        public IActionResult Create()
        {
            ViewData["IdDentista"] = new SelectList(_context.Dentista, "IdDentista", "ApellidoDentista");
            ViewData["IdRecepcionista"] = new SelectList(_context.Recepcionista, "IdRecepcionista", "ApellidoRecepcionista");
            return View();
        }

        // POST: Reunion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroReunion,Dia,IdDentista,IdRecepcionista,DetallesReunion")] Reunion reunion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reunion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDentista"] = new SelectList(_context.Dentista, "IdDentista", "ApellidoDentista", reunion.IdDentista);
            ViewData["IdRecepcionista"] = new SelectList(_context.Recepcionista, "IdRecepcionista", "ApellidoRecepcionista", reunion.IdRecepcionista);
            return View(reunion);
        }

        // GET: Reunion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reunion = await _context.Reunion.FindAsync(id);
            if (reunion == null)
            {
                return NotFound();
            }
            ViewData["IdDentista"] = new SelectList(_context.Dentista, "IdDentista", "ApellidoDentista", reunion.IdDentista);
            ViewData["IdRecepcionista"] = new SelectList(_context.Recepcionista, "IdRecepcionista", "ApellidoRecepcionista", reunion.IdRecepcionista);
            return View(reunion);
        }

        // POST: Reunion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroReunion,Dia,IdDentista,IdRecepcionista,DetallesReunion")] Reunion reunion)
        {
            if (id != reunion.NumeroReunion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reunion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReunionExists(reunion.NumeroReunion))
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
            ViewData["IdDentista"] = new SelectList(_context.Dentista, "IdDentista", "ApellidoDentista", reunion.IdDentista);
            ViewData["IdRecepcionista"] = new SelectList(_context.Recepcionista, "IdRecepcionista", "ApellidoRecepcionista", reunion.IdRecepcionista);
            return View(reunion);
        }

        // GET: Reunion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reunion = await _context.Reunion
                .Include(r => r.IdDentistaNavigation)
                .Include(r => r.IdRecepcionistaNavigation)
                .FirstOrDefaultAsync(m => m.NumeroReunion == id);
            if (reunion == null)
            {
                return NotFound();
            }

            return View(reunion);
        }

        // POST: Reunion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reunion = await _context.Reunion.FindAsync(id);
            _context.Reunion.Remove(reunion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReunionExists(int id)
        {
            return _context.Reunion.Any(e => e.NumeroReunion == id);
        }
    }
}
