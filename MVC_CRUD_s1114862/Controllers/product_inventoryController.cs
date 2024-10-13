using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_s1114862.Models;

namespace MVC_CRUD_s1114862.Controllers
{
    public class product_inventoryController : Controller
    {
        private storehouseEntities db = new storehouseEntities();

        // GET: product_inventory
        public ActionResult Index()
        {
            return View(db.product_inventory.ToList());
        }

        // GET: product_inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_inventory product_inventory = db.product_inventory.Find(id);
            if (product_inventory == null)
            {
                return HttpNotFound();
            }
            return View(product_inventory);
        }

        // GET: product_inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: product_inventory/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,serial_number,product,price,inventory,Order")] product_inventory product_inventory)
        {
            if (ModelState.IsValid)
            {
                db.product_inventory.Add(product_inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_inventory);
        }

        // GET: product_inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_inventory product_inventory = db.product_inventory.Find(id);
            if (product_inventory == null)
            {
                return HttpNotFound();
            }
            return View(product_inventory);
        }

        // POST: product_inventory/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,serial_number,product,price,inventory,Order")] product_inventory product_inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_inventory);
        }

        // GET: product_inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product_inventory product_inventory = db.product_inventory.Find(id);
            if (product_inventory == null)
            {
                return HttpNotFound();
            }
            return View(product_inventory);
        }

        // POST: product_inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product_inventory product_inventory = db.product_inventory.Find(id);
            db.product_inventory.Remove(product_inventory);
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
