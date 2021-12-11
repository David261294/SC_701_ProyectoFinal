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
    public class TratamientoController : Controller
    {
        private readonly DBDentistaContext _context;

        public TratamientoController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: Tratamiento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tratamiento.ToListAsync());
        }

        // GET: Tratamiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamiento = await _context.Tratamiento
                .FirstOrDefaultAsync(m => m.IdTratamiento == id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return View(tratamiento);
        }

        // GET: Tratamiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tratamiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTratamiento,NombreTratamiento,CostoTratamiento")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tratamiento);
        }

        // GET: Tratamiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamiento = await _context.Tratamiento.FindAsync(id);
            if (tratamiento == null)
            {
                return NotFound();
            }
            return View(tratamiento);
        }

        // POST: Tratamiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTratamiento,NombreTratamiento,CostoTratamiento")] Tratamiento tratamiento)
        {
            if (id != tratamiento.IdTratamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamientoExists(tratamiento.IdTratamiento))
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
            return View(tratamiento);
        }

        // GET: Tratamiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamiento = await _context.Tratamiento
                .FirstOrDefaultAsync(m => m.IdTratamiento == id);
            if (tratamiento == null)
            {
                return NotFound();
            }

            return View(tratamiento);
        }

        // POST: Tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratamiento = await _context.Tratamiento.FindAsync(id);
            _context.Tratamiento.Remove(tratamiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamientoExists(int id)
        {
            return _context.Tratamiento.Any(e => e.IdTratamiento == id);
        }
    }
}
