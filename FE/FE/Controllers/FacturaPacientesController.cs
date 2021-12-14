using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Models;
using FE.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace FE.Controllers
{
    [Authorize]
    public class FacturaPacientesController : Controller
    {

        ExpedientePacienteServices expedientePacienteServicios = new ExpedientePacienteServices();
        FacturaPacienteServices facturaPacienteServicios = new FacturaPacienteServices();
        public FacturaPacientesController()
        {
           
        }

        // GET: FacturaPacientes
        public async Task<IActionResult> Index()
        {
            return View(await facturaPacienteServicios.GetAllAsync());
        }

        // GET: FacturaPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPaciente = facturaPacienteServicios.GetById(id);
            if (facturaPaciente == null)
            {
                return NotFound();
            }

            return View(facturaPaciente);
        }

        // GET: FacturaPacientes/Create
        public IActionResult Create()
        {
            ViewData["IdPaciente"] = new SelectList(expedientePacienteServicios.GetAll(), "IdPaciente", "NombrePaciente");
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
                if (facturaPacienteServicios.Create(facturaPaciente))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdPaciente"] = new SelectList(expedientePacienteServicios.GetAll(), "IdPaciente", "NombrePaciente", facturaPaciente.IdPaciente);
            return View(facturaPaciente);
        }

        // GET: FacturaPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPaciente = facturaPacienteServicios.GetById(id);
            if (facturaPaciente == null)
            {
                return NotFound();
            }
            ViewData["IdPaciente"] = new SelectList(expedientePacienteServicios.GetAll(), "IdPaciente", "NombrePaciente", facturaPaciente.IdPaciente);
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
                    if (facturaPacienteServicios.Updated(id, facturaPaciente))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    var aux2 = facturaPacienteServicios.GetById(id);
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
            ViewData["IdPaciente"] = new SelectList(expedientePacienteServicios.GetAll(), "IdPaciente", "NombrePaciente", facturaPaciente.IdPaciente);
            return View(facturaPaciente);
        }

        // GET: FacturaPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPaciente = facturaPacienteServicios.GetById(id);
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
            if (await facturaPacienteServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool FacturaPacienteExists(int id)
        //{
        //    return _context.FacturaPaciente.Any(e => e.CodigoFactura == id);
        //}
    }
}
