using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Real_Estate_Project.Models.DbContext;

namespace Real_Estate_Project.Controllers
{
    public class CustomerController : Controller
    {
        private FPTRealEstateEntities db = new FPTRealEstateEntities();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.CustomerInfomations.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfomation customerInfomation = db.CustomerInfomations.Find(id);
            if (customerInfomation == null)
            {
                return HttpNotFound();
            }
            return View(customerInfomation);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,BirthDay,Address,PhoneNumber,Email,UserName,Password,CompanyCode,CreatedBy,CreatedDate,ModifiedDate,ModifiedBy,IsActive,IsDelete")] CustomerInfomation customerInfomation)
        {
            if (ModelState.IsValid)
            {
                db.CustomerInfomations.Add(customerInfomation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerInfomation);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfomation customerInfomation = db.CustomerInfomations.Find(id);
            if (customerInfomation == null)
            {
                return HttpNotFound();
            }
            return View(customerInfomation);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,BirthDay,Address,PhoneNumber,Email,UserName,Password,CompanyCode,CreatedBy,CreatedDate,ModifiedDate,ModifiedBy,IsActive,IsDelete")] CustomerInfomation customerInfomation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInfomation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInfomation);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfomation customerInfomation = db.CustomerInfomations.Find(id);
            if (customerInfomation == null)
            {
                return HttpNotFound();
            }
            return View(customerInfomation);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerInfomation customerInfomation = db.CustomerInfomations.Find(id);
            db.CustomerInfomations.Remove(customerInfomation);
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
