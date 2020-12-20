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
    public class HouseCategoriesController : Controller
    {
        private readonly FPTRealEstateEntities _dbContext = null;

        public HouseCategoriesController()
        {
            _dbContext = new FPTRealEstateEntities();
        }

        // GET: HouseCategories
        public ActionResult Index()
        {
            return View(_dbContext.HouseCategories.ToList());
        }

        // GET: HouseCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseCategory houseCategory = _dbContext.HouseCategories.Find(id);
            if (houseCategory == null)
            {
                return HttpNotFound();
            }
            return View(houseCategory);
        }

        // GET: HouseCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName")] HouseCategory houseCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.HouseCategories.Add(houseCategory);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(houseCategory);
        }

        // GET: HouseCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseCategory houseCategory = _dbContext.HouseCategories.Find(id);
            if (houseCategory == null)
            {
                return HttpNotFound();
            }
            return View(houseCategory);
        }

        // POST: HouseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName")] HouseCategory houseCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(houseCategory).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseCategory);
        }

        // GET: HouseCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseCategory houseCategory = _dbContext.HouseCategories.Find(id);
            if (houseCategory == null)
            {
                return HttpNotFound();
            }
            return View(houseCategory);
        }

        // POST: HouseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseCategory houseCategory = _dbContext.HouseCategories.Find(id);
            _dbContext.HouseCategories.Remove(houseCategory);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
