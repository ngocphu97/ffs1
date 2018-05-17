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
    public class OrderProductsController : Controller
    {
        private FastFoodStoreContext db = new FastFoodStoreContext();

        // GET: OrderProducts
        public ActionResult Index(int? id)
        {
            var viewModel = new OrderIndexData();
            viewModel.OrderProducts = db.OrderProduct.Include(i => i.OrderProductDetails);

            if (id != null)
            {
                ViewBag.OrderProductID = id.Value;
                //viewModel.ImportDetails = viewModel.ImportProductss.Where(
                //i => i.ImportProductsID == id.Value).Single().ImportDetail;
                viewModel.OrderProductDetails = db.OrderProductDetail2.Where(i => i.OrerProductID == id.Value);
            }
            return View(viewModel);
        }
        public ActionResult SaveOrder(String buyer, DateTime date, long total, OrderProductDetail2[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (date != null && order != null)
            {
                OrderProduct model = new OrderProduct();
                model.Buyer = buyer;
                model.Status = 0;
                model.DateIn = date;
                model.Total = total;
                db.OrderProduct.Add(model);
                db.SaveChanges();
                int id = model.ID;

                foreach (var item in order)
                {
                    OrderProductDetail2 O = new OrderProductDetail2();
                    O.ProductID = item.ProductID;
                    O.Amount = item.Amount;
                    O.OrerProductID = id;
                    db.OrderProductDetail2.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
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
