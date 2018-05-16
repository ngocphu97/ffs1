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
using FastFoodStore.ViewModels;

namespace FastFoodStore.Controllers
{
    public class ImportProductsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: ImportProducts
        public ActionResult Index(int? id)
        {
            //var importProducts = db.ImportProducts.Include(i => i.Staff);
            //return View(importProducts.ToList());

            var viewModel = new ImportIndexData();
            viewModel.ImportProductss = db.ImportProducts.Include(i => i.ImportDetail);

            if (id != null)
            {
                ViewBag.ImportProductID = id.Value;
                viewModel.ImportDetails = viewModel.ImportProductss.Where(
                i => i.ImportProductsID == id.Value).Single().ImportDetail;
            }
            return View(viewModel);
        }

        // GET: ImportProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportProducts importProducts = db.ImportProducts.Find(id);
            if (importProducts == null)
            {
                return HttpNotFound();
            }
            return View(importProducts);
        }

        // GET: ImportProducts/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name");
            return View();
        }

        // POST: ImportProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImportProductsID,StaffID,Date,Total")] ImportProducts importProducts)
        {
            if (ModelState.IsValid)
            {
                db.ImportProducts.Add(importProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name", importProducts.StaffID);
            return View(importProducts);
        }

        // GET: ImportProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportProducts importProducts = db.ImportProducts.Find(id);
            if (importProducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name", importProducts.StaffID);
            return View(importProducts);
        }

        // POST: ImportProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImportProductsID,StaffID,Date,Total")] ImportProducts importProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.Staff, "StaffID", "Name", importProducts.StaffID);
            return View(importProducts);
        }

        // GET: ImportProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportProducts importProducts = db.ImportProducts.Find(id);
            if (importProducts == null)
            {
                return HttpNotFound();
            }
            return View(importProducts);
        }

        // POST: ImportProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImportProducts importProducts = db.ImportProducts.Find(id);
            db.ImportProducts.Remove(importProducts);
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
