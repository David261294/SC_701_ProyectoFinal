using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Models;
using FE.Servicios;

namespace FE.Controllers
{
    public class CitasController : Controller
    {

        CitasServices servicios = new CitasServices();
        public CitasController()
        {
            
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            return View(servicios.GetAll());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = servicios.GetById(id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCitas,NombrePacienteCita,ApellidoPacienteCita,DíaCita,MesCita,AñoCita,HoraCita")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                if (servicios.Create(citas))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(citas);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = servicios.GetById(id);
            if (citas == null)
            {
                return NotFound();
            }
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCitas,NombrePacienteCita,ApellidoPacienteCita,DíaCita,MesCita,AñoCita,HoraCita")] Citas citas)
        {
            if (id != citas.IdCitas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (servicios.Updated(id, citas))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    var aux2 = servicios.GetById(id);
                    if (aux2 == null)
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
            return View(citas);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = servicios.GetById(id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await servicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool CitasExists(int id)
        //{
        //    return _context.Citas.Any(e => e.IdCitas == id);
        //}
    }
}

