using Microsoft.AspNetCore.Mvc;
using System;
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
    public class DetalleFacturasController : Controller
    {

        ProductoServices productoServicios = new ProductoServices();
        TratamientoServices tratamientoServicios = new TratamientoServices();
        FacturaPacienteServices facturaPacienteServicios = new FacturaPacienteServices();
        DetalleFacturaServices detalleFacturaServicios = new DetalleFacturaServices();
        public DetalleFacturasController()
        {
            
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index()
        {
            return View(await detalleFacturaServicios.GetAllAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = detalleFacturaServicios.GetById(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["CodigoFactura"] = new SelectList(facturaPacienteServicios.GetAll(), "CodigoFactura", "CodigoFactura");
            ViewData["IdProducto"] = new SelectList(productoServicios.GetAll(), "IdProducto", "NombreProducto");
            ViewData["IdTratamiento"] = new SelectList(tratamientoServicios.GetAll(), "IdTratamiento", "NombreTratamiento");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDetalle,CodigoFactura,IdTratamiento,IdProducto,Cantidad,PrecioFinal")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                if (detalleFacturaServicios.Create(detalleFactura))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CodigoFactura"] = new SelectList(facturaPacienteServicios.GetAll(), "CodigoFactura", "CodigoFactura", detalleFactura.CodigoFactura);
            ViewData["IdProducto"] = new SelectList(productoServicios.GetAll(), "IdProducto", "NombreProducto", detalleFactura.IdProducto);
            ViewData["IdTratamiento"] = new SelectList(tratamientoServicios.GetAll(), "IdTratamiento", "NombreTratamiento", detalleFactura.IdTratamiento);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = detalleFacturaServicios.GetById(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["CodigoFactura"] = new SelectList(facturaPacienteServicios.GetAll(), "CodigoFactura", "CodigoFactura", detalleFactura.CodigoFactura);
            ViewData["IdProducto"] = new SelectList(productoServicios.GetAll(), "IdProducto", "NombreProducto", detalleFactura.IdProducto);
            ViewData["IdTratamiento"] = new SelectList(tratamientoServicios.GetAll(), "IdTratamiento", "NombreTratamiento", detalleFactura.IdTratamiento);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDetalle,CodigoFactura,IdTratamiento,IdProducto,Cantidad,PrecioFinal")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.CodigoDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (detalleFacturaServicios.Updated(id, detalleFactura))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    var aux2 = detalleFacturaServicios.GetById(id);
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
            ViewData["CodigoFactura"] = new SelectList(facturaPacienteServicios.GetAll(), "CodigoFactura", "CodigoFactura", detalleFactura.CodigoFactura);
            ViewData["IdProducto"] = new SelectList(productoServicios.GetAll(), "IdProducto", "NombreProducto", detalleFactura.IdProducto);
            ViewData["IdTratamiento"] = new SelectList(tratamientoServicios.GetAll(), "IdTratamiento", "NombreTratamiento", detalleFactura.IdTratamiento);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = detalleFacturaServicios.GetById(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await detalleFacturaServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool DetalleFacturaExists(int id)
        //{
        //    return _context.DetalleFactura.Any(e => e.CodigoDetalle == id);
        //}
    }
}
