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
    public class ExpedientePacientesController : Controller
    {

        ExpedientePacienteServices servicios = new ExpedientePacienteServices();
        public ExpedientePacientesController()
        {
            
        }

        // GET: ExpedientePacientes
        public async Task<IActionResult> Index()
        {
            return View(servicios.GetAll());
        }

        // GET: ExpedientePacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientePaciente = servicios.GetById(id);
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
                if (servicios.Create(expedientePaciente))
                {
                    return RedirectToAction(nameof(Index));
                }
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

            var expedientePaciente = servicios.GetById(id);
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
                    if (servicios.Updated(id, expedientePaciente))
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
            return View(expedientePaciente);
        }

        // GET: ExpedientePacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expedientePaciente = servicios.GetById(id);
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
            if (await servicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool ExpedientePacienteExists(int id)
        //{
        //    return _context.ExpedientePaciente.Any(e => e.IdPaciente == id);
        //}
    }
}
