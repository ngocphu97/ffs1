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
    public class OrderProductDetailsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: OrderProductDetails
        public ActionResult Index()
        {
            return View(db.OrderProductDetail.ToList());
        }

        // GET: OrderProductDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProductDetail orderProductDetail = db.OrderProductDetail.Find(id);
            if (orderProductDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderProductDetail);
        }

        // GET: OrderProductDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderProductDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderProductDetailID,OrerProductID")] OrderProductDetail orderProductDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderProductDetail.Add(orderProductDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderProductDetail);
        }

        // GET: OrderProductDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProductDetail orderProductDetail = db.OrderProductDetail.Find(id);
            if (orderProductDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderProductDetail);
        }

        // POST: OrderProductDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderProductDetailID,OrerProductID")] OrderProductDetail orderProductDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderProductDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderProductDetail);
        }

        // GET: OrderProductDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProductDetail orderProductDetail = db.OrderProductDetail.Find(id);
            if (orderProductDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderProductDetail);
        }

        // POST: OrderProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderProductDetail orderProductDetail = db.OrderProductDetail.Find(id);
            db.OrderProductDetail.Remove(orderProductDetail);
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
