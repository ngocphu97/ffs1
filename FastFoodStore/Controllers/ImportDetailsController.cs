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
    public class ImportDetailsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: ImportDetails
        public ActionResult Index()
        {
            return View(db.ImportDetail.ToList());
        }

        // GET: ImportDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportDetail importDetail = db.ImportDetail.Find(id);
            if (importDetail == null)
            {
                return HttpNotFound();
            }
            return View(importDetail);
        }

        // GET: ImportDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImportDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImportDetailID,ImportID,ProductID,Amount,PriceImport,Total")] ImportDetail importDetail)
        {
            if (ModelState.IsValid)
            {
                db.ImportDetail.Add(importDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(importDetail);
        }

        // GET: ImportDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportDetail importDetail = db.ImportDetail.Find(id);
            if (importDetail == null)
            {
                return HttpNotFound();
            }
            return View(importDetail);
        }

        // POST: ImportDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImportDetailID,ImportID,ProductID,Amount,PriceImport,Total")] ImportDetail importDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(importDetail);
        }

        // GET: ImportDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportDetail importDetail = db.ImportDetail.Find(id);
            if (importDetail == null)
            {
                return HttpNotFound();
            }
            return View(importDetail);
        }

        // POST: ImportDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImportDetail importDetail = db.ImportDetail.Find(id);
            db.ImportDetail.Remove(importDetail);
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
