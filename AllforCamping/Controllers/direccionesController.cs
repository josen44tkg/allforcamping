using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllforCamping.Models;

namespace AllforCamping.Controllers
{
    public class direccionesController : Controller
    {
        private allforcampingEntities1 db = new allforcampingEntities1();

        // GET: direcciones
        public ActionResult Index()
        {
            var direcciones = db.direcciones.Include(d => d.usuarios);
            return View(direcciones.ToList());
        }

        // GET: direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direcciones direcciones = db.direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // GET: direcciones/Create
        public ActionResult Create()
        {
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre");
            return View();
        }

        // POST: direcciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,usuario,calle,colonia,municipio,estado,telefono,cp")] direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.direcciones.Add(direcciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre", direcciones.usuario);
            return View(direcciones);
        }

        // GET: direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direcciones direcciones = db.direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre", direcciones.usuario);
            return View(direcciones);
        }

        // POST: direcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,usuario,calle,colonia,municipio,estado,telefono,cp")] direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direcciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuario = new SelectList(db.usuarios, "Id", "nombre", direcciones.usuario);
            return View(direcciones);
        }

        // GET: direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direcciones direcciones = db.direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            direcciones direcciones = db.direcciones.Find(id);
            db.direcciones.Remove(direcciones);
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
