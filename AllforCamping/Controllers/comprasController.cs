using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllforCamping.Models;

namespace AllforCamping.Controllers
{
    public class comprasController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: compras
        public async Task<ActionResult> Index()
        {
            return View(await db.compras.ToListAsync());
        }

        // GET: compras/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compras compras = await db.compras.FindAsync(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // GET: compras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,proveedor,producto,cantidad,total,status")] compras compras)
        {
            if (ModelState.IsValid)
            {
                db.compras.Add(compras);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(compras);
        }

        // GET: compras/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compras compras = await db.compras.FindAsync(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // POST: compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,proveedor,producto,cantidad,total,status")] compras compras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compras).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(compras);
        }

        // GET: compras/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compras compras = await db.compras.FindAsync(id);
            if (compras == null)
            {
                return HttpNotFound();
            }
            return View(compras);
        }

        // POST: compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            compras compras = await db.compras.FindAsync(id);
            db.compras.Remove(compras);
            await db.SaveChangesAsync();
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
