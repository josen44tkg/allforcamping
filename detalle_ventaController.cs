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
    public class detalle_ventaController : Controller
    {
        private allforcampingEntities db = new allforcampingEntities();

        // GET: detalle_venta
        public ActionResult Index()
        {
            var detalle_venta = db.detalle_venta.Include(d => d.productos).Include(d => d.ventas);
            return View(detalle_venta.ToList());
        }

        // GET: detalle_venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // GET: detalle_venta/Create
        public ActionResult Create()
        {
            ViewBag.producto = new SelectList(db.productos, "Id", "nombre");
            ViewBag.venta = new SelectList(db.ventas, "Id", "pago");
            return View();
        }

        // POST: detalle_venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,producto,venta,cantidad,subtotal")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.detalle_venta.Add(detalle_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.producto = new SelectList(db.productos, "Id", "nombre", detalle_venta.producto);
            ViewBag.venta = new SelectList(db.ventas, "Id", "pago", detalle_venta.venta);
            return View(detalle_venta);
        }

        // GET: detalle_venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.producto = new SelectList(db.productos, "Id", "nombre", detalle_venta.producto);
            ViewBag.venta = new SelectList(db.ventas, "Id", "pago", detalle_venta.venta);
            return View(detalle_venta);
        }

        // POST: detalle_venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,producto,venta,cantidad,subtotal")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.producto = new SelectList(db.productos, "Id", "nombre", detalle_venta.producto);
            ViewBag.venta = new SelectList(db.ventas, "Id", "pago", detalle_venta.venta);
            return View(detalle_venta);
        }

        // GET: detalle_venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: detalle_venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            db.detalle_venta.Remove(detalle_venta);
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
