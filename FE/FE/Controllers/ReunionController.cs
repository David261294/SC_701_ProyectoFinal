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
    public class ReunionController : Controller
    {

        DentistaServices dentistaServicios = new DentistaServices();
        RecepcionistaServices recepcionistaServicios = new RecepcionistaServices();
        ReunionServices reunionServicios = new ReunionServices();
        public ReunionController()
        {

        }

        // GET: Reunion
        public async Task<IActionResult> Index()
        {
            return View(await reunionServicios.GetAllAsync());

        }

        // GET: Reunion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reunion = reunionServicios.GetById(id);
            if (reunion == null)
            {
                return NotFound();
            }

            return View(reunion);
        }

        // GET: Reunion/Create
        public IActionResult Create()
        {
            ViewData["IdDentista"] = new SelectList(dentistaServicios.GetAll(), "IdDentista", "NombreDentista");
            ViewData["IdRecepcionista"] = new SelectList(recepcionistaServicios.GetAll(), "IdRecepcionista", "NombreRecepcionista");
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
                if (reunionServicios.Create(reunion))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdDentista"] = new SelectList(dentistaServicios.GetAll(), "IdDentista", "NombreDentista", reunion.IdDentista);
            ViewData["IdRecepcionista"] = new SelectList(recepcionistaServicios.GetAll(), "IdRecepcionista", "NombreRecepcionista", reunion.IdRecepcionista);
            return View(reunion);
        }

        // GET: Reunion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reunion = reunionServicios.GetById(id);
            if (reunion == null)
            {
                return NotFound();
            }
            ViewData["IdDentista"] = new SelectList(dentistaServicios.GetAll(), "IdDentista", "NombreDentista", reunion.IdDentista);
            ViewData["IdRecepcionista"] = new SelectList(recepcionistaServicios.GetAll(), "IdRecepcionista", "NombreRecepcionista", reunion.IdRecepcionista);
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
                    if (reunionServicios.Updated(id, reunion))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    var aux2 = reunionServicios.GetById(id);
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
            ViewData["IdDentista"] = new SelectList(dentistaServicios.GetAll(), "IdDentista", "NombreDentista", reunion.IdDentista);
            ViewData["IdRecepcionista"] = new SelectList(recepcionistaServicios.GetAll(), "IdRecepcionista", "NombreRecepcionista", reunion.IdRecepcionista);
            return View(reunion);
        }

        // GET: Reunion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reunion = reunionServicios.GetById(id);
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
            if (await reunionServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

        //private bool ReunionExists(int id)
        //{
        //    return _context.Reunion.Any(e => e.NumeroReunion == id);
        //}

