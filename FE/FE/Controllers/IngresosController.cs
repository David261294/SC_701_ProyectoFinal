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
    public class IngresosController : Controller
    {

        DetalleFacturaServices detalleFacturaServicios = new DetalleFacturaServices();
        IngresoServices ingresoServicios = new IngresoServices();
        public IngresosController()
        {
            
        }

        // GET: Ingresos
        public async Task<IActionResult> Index()
        {
            return View(await ingresoServicios.GetAllAsync());
        }

        // GET: Ingresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresos = ingresoServicios.GetById(id);
            if (ingresos == null)
            {
                return NotFound();
            }

            return View(ingresos);
        }

        // GET: Ingresos/Create
        public IActionResult Create()
        {
            ViewData["CodigoDetalle"] = new SelectList(detalleFacturaServicios.GetAll(), "CodigoDetalle", "PrecioFinal");
            return View();
        }

        // POST: Ingresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIngreso,FechaIngreso,CodigoDetalle")] Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                if (ingresoServicios.Create(ingresos))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CodigoDetalle"] = new SelectList(detalleFacturaServicios.GetAll(), "CodigoDetalle", "PrecioFinal", ingresos.CodigoDetalle);
            return View(ingresos);
        }

        // GET: Ingresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresos = ingresoServicios.GetById(id);
            if (ingresos == null)
            {
                return NotFound();
            }
            ViewData["CodigoDetalle"] = new SelectList(detalleFacturaServicios.GetAll(), "CodigoDetalle", "PrecioFinal", ingresos.CodigoDetalle);
            return View(ingresos);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIngreso,FechaIngreso,CodigoDetalle")] Ingresos ingresos)
        {
            if (id != ingresos.IdIngreso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ingresoServicios.Updated(id, ingresos))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    var aux2 = ingresoServicios.GetById(id);
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
            ViewData["CodigoDetalle"] = new SelectList(detalleFacturaServicios.GetAll(), "CodigoDetalle", "PrecioFinal", ingresos.CodigoDetalle);
            return View(ingresos);
        }

        // GET: Ingresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresos = ingresoServicios.GetById(id);
            if (ingresos == null)
            {
                return NotFound();
            }

            return View(ingresos);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await ingresoServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool IngresosExists(int id)
        //{
        //    return _context.Ingresos.Any(e => e.IdIngreso == id);
        //}
    }
}
