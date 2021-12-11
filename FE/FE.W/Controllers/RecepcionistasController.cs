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
    public class RecepcionistasController : Controller
    {
        private readonly DBDentistaContext _context;

        public RecepcionistasController(DBDentistaContext context)
        {
            _context = context;
        }

        // GET: Recepcionistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recepcionista.ToListAsync());
        }

        // GET: Recepcionistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionista
                .FirstOrDefaultAsync(m => m.IdRecepcionista == id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            return View(recepcionista);
        }

        // GET: Recepcionistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepcionistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecepcionista,NombreRecepcionista,ApellidoRecepcionista,Contraseña")] Recepcionista recepcionista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recepcionista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recepcionista);
        }

        // GET: Recepcionistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionista.FindAsync(id);
            if (recepcionista == null)
            {
                return NotFound();
            }
            return View(recepcionista);
        }

        // POST: Recepcionistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecepcionista,NombreRecepcionista,ApellidoRecepcionista,Contraseña")] Recepcionista recepcionista)
        {
            if (id != recepcionista.IdRecepcionista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepcionista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionistaExists(recepcionista.IdRecepcionista))
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
            return View(recepcionista);
        }

        // GET: Recepcionistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionista = await _context.Recepcionista
                .FirstOrDefaultAsync(m => m.IdRecepcionista == id);
            if (recepcionista == null)
            {
                return NotFound();
            }

            return View(recepcionista);
        }

        // POST: Recepcionistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recepcionista = await _context.Recepcionista.FindAsync(id);
            _context.Recepcionista.Remove(recepcionista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecepcionistaExists(int id)
        {
            return _context.Recepcionista.Any(e => e.IdRecepcionista == id);
        }
    }
}
