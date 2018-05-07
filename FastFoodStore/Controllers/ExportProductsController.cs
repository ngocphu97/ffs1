using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastFoodStore.DAL;
using FastFoodStore.Models;

namespace FastFoodStore.Controllers
{
    public class ExportProductsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: ExportProducts
        public ActionResult Index()
        {
            var exportProduct = db.ExportProduct.Include(e => e.Staff);
            return View(exportProduct.ToList());
        }

        // GET: ExportProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportProduct exportProduct = db.ExportProduct.Find(id);
            if (exportProduct == null)
            {
                return HttpNotFound();
            }
            return View(exportProduct);
        }

        // GET: ExportProducts/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name");
            return View();
        }

        // POST: ExportProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExportProductID,StaffID,Date,Total")] ExportProduct exportProduct)
        {
            if (ModelState.IsValid)
            {
                db.ExportProduct.Add(exportProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name", exportProduct.StaffID);
            return View(exportProduct);
        }

        // GET: ExportProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportProduct exportProduct = db.ExportProduct.Find(id);
            if (exportProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name", exportProduct.StaffID);
            return View(exportProduct);
        }

        // POST: ExportProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExportProductID,StaffID,Date,Total")] ExportProduct exportProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name", exportProduct.StaffID);
            return View(exportProduct);
        }

        // GET: ExportProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportProduct exportProduct = db.ExportProduct.Find(id);
            if (exportProduct == null)
            {
                return HttpNotFound();
            }
            return View(exportProduct);
        }

        // POST: ExportProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExportProduct exportProduct = db.ExportProduct.Find(id);
            db.ExportProduct.Remove(exportProduct);
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
