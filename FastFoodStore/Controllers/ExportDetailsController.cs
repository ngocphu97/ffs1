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
    public class ExportDetailsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: ExportDetails
        public ActionResult Index()
        {
            return View(db.ExportDetail.ToList());
        }

        // GET: ExportDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportDetail exportDetail = db.ExportDetail.Find(id);
            if (exportDetail == null)
            {
                return HttpNotFound();
            }
            return View(exportDetail);
        }

        // GET: ExportDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExportDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExportDetailID,ExportID,ProductID,Amount,Total")] ExportDetail exportDetail)
        {
            if (ModelState.IsValid)
            {
                db.ExportDetail.Add(exportDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exportDetail);
        }

        // GET: ExportDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportDetail exportDetail = db.ExportDetail.Find(id);
            if (exportDetail == null)
            {
                return HttpNotFound();
            }
            return View(exportDetail);
        }

        // POST: ExportDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExportDetailID,ExportID,ProductID,Amount,Total")] ExportDetail exportDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exportDetail);
        }

        // GET: ExportDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportDetail exportDetail = db.ExportDetail.Find(id);
            if (exportDetail == null)
            {
                return HttpNotFound();
            }
            return View(exportDetail);
        }

        // POST: ExportDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExportDetail exportDetail = db.ExportDetail.Find(id);
            db.ExportDetail.Remove(exportDetail);
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
