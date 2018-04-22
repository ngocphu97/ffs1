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
    public class OrderProductsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: OrderProducts
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
            ViewBag.DateSortParm = sortOrder == "DateIn" ? "date_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Status" ? "stt_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Buyer" ? "buyer_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Total" ? "total_desc" : "";
            
            var orderProducts = from s in db.OrderProduct
                           select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                orderProducts = orderProducts.Where(s => s.Buyer.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ID_desc":
                    orderProducts = orderProducts.OrderByDescending(s => s.ID);
                    break;
                case "date_desc":
                    orderProducts = orderProducts.OrderByDescending(s => s.DateIn);
                    break;
                case "stt_desc":
                    orderProducts = orderProducts.OrderByDescending(s => s.Status);
                    break;
                case "buyer_desc":
                    orderProducts = orderProducts.OrderByDescending(s => s.Buyer);
                    break;
                case "total_desc":
                    orderProducts = orderProducts.OrderByDescending(s => s.Total);
                    break;

                default:
                    orderProducts = orderProducts.OrderBy(s => s.ID);
                    break;
            }
            return View(orderProducts.ToList());
        }

        // GET: OrderProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProduct orderProduct = db.OrderProduct.Find(id);
            if (orderProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderProduct);
        }

        // GET: OrderProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateIn,Status,Buyer,Total")] OrderProduct orderProduct)
        {
            if (ModelState.IsValid)
            {
                db.OrderProduct.Add(orderProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderProduct);
        }

        // GET: OrderProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProduct orderProduct = db.OrderProduct.Find(id);
            if (orderProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderProduct);
        }

        // POST: OrderProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateIn,Status,Buyer,Total")] OrderProduct orderProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderProduct);
        }

        // GET: OrderProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProduct orderProduct = db.OrderProduct.Find(id);
            if (orderProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderProduct);
        }

        // POST: OrderProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderProduct orderProduct = db.OrderProduct.Find(id);
            db.OrderProduct.Remove(orderProduct);
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
