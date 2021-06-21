using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using alforcampingv2.Models;

namespace alforcampingv2.Controllers
{
    public class ventasController : Controller
    {
        private allforcampingEntities db = new allforcampingEntities();

        // GET: ventas
        public ActionResult Index()
        {
            var ventas = db.ventas.Include(v => v.paqueterias).Include(v => v.usuarios);
            return View(ventas.ToList());
        }

        // GET: ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // GET: ventas/Create
        public ActionResult Create()
        {
            ViewBag.paqueteria = new SelectList(db.paqueterias, "Id", "nombre");
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre");
            return View();
        }

        // POST: ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fecha,total,usuario,pago,guia,fecha_envio,fecha_entrega,paqueteria")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paqueteria = new SelectList(db.paqueterias, "Id", "nombre", ventas.paqueteria);
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre", ventas.usuario);
            return View(ventas);
        }

        // GET: ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.paqueteria = new SelectList(db.paqueterias, "Id", "nombre", ventas.paqueteria);
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre", ventas.usuario);
            return View(ventas);
        }

        // POST: ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fecha,total,usuario,pago,guia,fecha_envio,fecha_entrega,paqueteria")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paqueteria = new SelectList(db.paqueterias, "Id", "nombre", ventas.paqueteria);
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre", ventas.usuario);
            return View(ventas);
        }

        // GET: ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ventas ventas = db.ventas.Find(id);
            db.ventas.Remove(ventas);
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
