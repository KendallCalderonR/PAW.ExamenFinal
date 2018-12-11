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
    public class RentasController : Controller
    {
        private WorkEntities db = new WorkEntities();

        // GET: Rentas
        public ActionResult Index()
        {
            var renta = db.Renta.Include(r => r.Cliente).Include(r => r.CopiaPelicula);
            return View(renta.ToList());
        }

        // GET: Rentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // GET: Rentas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre");
            ViewBag.IdCopiaPelicula = new SelectList(db.CopiaPelicula, "IdCopiaPelicula", "NombreOriginal");
            return View();
        }

        // POST: Rentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRenta,FechaRenta,FechaDebeDevolver,FechaDevolucion,IdCliente,IdCopiaPelicula")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                db.Renta.Add(renta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", renta.IdCliente);
            ViewBag.IdCopiaPelicula = new SelectList(db.CopiaPelicula, "IdCopiaPelicula", "NombreOriginal", renta.IdCopiaPelicula);
            return View(renta);
        }

        // GET: Rentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", renta.IdCliente);
            ViewBag.IdCopiaPelicula = new SelectList(db.CopiaPelicula, "IdCopiaPelicula", "NombreOriginal", renta.IdCopiaPelicula);
            return View(renta);
        }

        // POST: Rentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRenta,FechaRenta,FechaDebeDevolver,FechaDevolucion,IdCliente,IdCopiaPelicula")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", renta.IdCliente);
            ViewBag.IdCopiaPelicula = new SelectList(db.CopiaPelicula, "IdCopiaPelicula", "NombreOriginal", renta.IdCopiaPelicula);
            return View(renta);
        }

        // GET: Rentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // POST: Rentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renta renta = db.Renta.Find(id);
            db.Renta.Remove(renta);
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
