using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using exau3y4.Models;

namespace exau3y4.Controllers
{
    public class PaqueteriasController : Controller
    {
        private ContextEntities db = new ContextEntities();

        // GET: Paqueterias
        public ActionResult Index()
        {
            return View(db.Paqueterias.ToList());
        }

        // GET: Paqueterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paqueterias paqueterias = db.Paqueterias.Find(id);
            if (paqueterias == null)
            {
                return HttpNotFound();
            }
            return View(paqueterias);
        }

        // GET: Paqueterias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paqueterias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,RFC,Tel,Web,Direccion,Contacto,TelContacto")] Paqueterias paqueterias)
        {
            if (ModelState.IsValid)
            {
                db.Paqueterias.Add(paqueterias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paqueterias);
        }

        // GET: Paqueterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paqueterias paqueterias = db.Paqueterias.Find(id);
            if (paqueterias == null)
            {
                return HttpNotFound();
            }
            return View(paqueterias);
        }

        // POST: Paqueterias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,RFC,Tel,Web,Direccion,Contacto,TelContacto")] Paqueterias paqueterias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paqueterias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paqueterias);
        }

        // GET: Paqueterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paqueterias paqueterias = db.Paqueterias.Find(id);
            if (paqueterias == null)
            {
                return HttpNotFound();
            }
            return View(paqueterias);
        }

        // POST: Paqueterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paqueterias paqueterias = db.Paqueterias.Find(id);
            db.Paqueterias.Remove(paqueterias);
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
