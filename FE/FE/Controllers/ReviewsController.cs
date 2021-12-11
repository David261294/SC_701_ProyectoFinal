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
    public class ReviewsController : Controller
    {

        CitasServices citasServicios = new CitasServices();
        ReviewServices reviewServicios = new ReviewServices();
        public ReviewsController()
        {
           
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            
            return View(await reviewServicios.GetAllAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = reviewServicios.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["IdCitas"] = new SelectList(citasServicios.GetAll(), "IdCitas", "NombrePacienteCita");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReview,IdCitas,NombrePacienteCita,Comentario,Estrellas")] Review review)
        {
            if (ModelState.IsValid)
            {
                if (reviewServicios.Create(review))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdCitas"] = new SelectList(citasServicios.GetAll(), "IdCitas", "NombrePacienteCita", review.IdCitas);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = reviewServicios.GetById(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["IdCitas"] = new SelectList(citasServicios.GetAll(), "IdCitas", "NombrePacienteCita", review.IdCitas);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReview,IdCitas,NombrePacienteCita,Comentario,Estrellas")] Review review)
        {
            if (id != review.IdReview)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (reviewServicios.Updated(id, review))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    var aux2 = reviewServicios.GetById(id);
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
            ViewData["IdCitas"] = new SelectList(citasServicios.GetAll(), "IdCitas", "NombrePacienteCita", review.IdCitas);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = reviewServicios.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await reviewServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool ReviewExists(int id)
        //{
        //    return _context.Review.Any(e => e.IdReview == id);
        //}


    }
}
