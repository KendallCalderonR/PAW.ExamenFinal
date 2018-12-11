using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAW.ExamenFinal.ModelDB;

namespace PAW.ExamenFinal.WebApp.Controllers
{
    public class CopiaPeliculasController : Controller
    {
        private WorkEntities db = new WorkEntities();

        // GET: CopiaPeliculas
        public ActionResult Index()
        {
            return View(db.CopiaPelicula.ToList());
        }

        // GET: CopiaPeliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CopiaPelicula copiaPelicula = db.CopiaPelicula.Find(id);
            if (copiaPelicula == null)
            {
                return HttpNotFound();
            }
            return View(copiaPelicula);
        }

        // GET: CopiaPeliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CopiaPeliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCopiaPelicula,Medio,FechaCreacion,NombreOriginal,PublicadaEn,Genero,PerdidaDanada,FechaPerdidaDanada")] CopiaPelicula copiaPelicula)
        {
            if (ModelState.IsValid)
            {
                db.CopiaPelicula.Add(copiaPelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(copiaPelicula);
        }

        // GET: CopiaPeliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CopiaPelicula copiaPelicula = db.CopiaPelicula.Find(id);
            if (copiaPelicula == null)
            {
                return HttpNotFound();
            }
            return View(copiaPelicula);
        }

        // POST: CopiaPeliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCopiaPelicula,Medio,FechaCreacion,NombreOriginal,PublicadaEn,Genero,PerdidaDanada,FechaPerdidaDanada")] CopiaPelicula copiaPelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copiaPelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(copiaPelicula);
        }

        // GET: CopiaPeliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CopiaPelicula copiaPelicula = db.CopiaPelicula.Find(id);
            if (copiaPelicula == null)
            {
                return HttpNotFound();
            }
            return View(copiaPelicula);
        }

        // POST: CopiaPeliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CopiaPelicula copiaPelicula = db.CopiaPelicula.Find(id);
            db.CopiaPelicula.Remove(copiaPelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
