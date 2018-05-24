using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.WebApplication.Models;

namespace Assignment2.WebApplication.Controllers
{
    public class MaintainerController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Maitainer
        public ActionResult Index()
        {
            return View(db.Maintainer.ToList());
        }

        // GET: Maitainer/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainer maitainer = db.Maintainer.Find(id);
            if (maitainer == null)
            {
                return HttpNotFound();
            }
            return View(maitainer);
        }

        // GET: Maitainer/Save
        public ActionResult Save()
        {
            return View();
        }

        // POST: Maitainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Day,Weather,Outfit,Temperature,LastMaintainerId")] Maintainer maitainer)
        {
            if (ModelState.IsValid)
            {
                db.Maintainer.Add(maitainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maitainer);
        }

        // GET: Maitainer/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainer maitainer = db.Maintainer.Find(id);
            if (maitainer == null)
            {
                return HttpNotFound();
            }
            return View(maitainer);
        }

        // POST: Maitainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Day,Weather,Outfit,Temperature,LastMaintainerId")] Maintainer maitainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maitainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maitainer);
        }

        // GET: Maitainer/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainer maitainer = db.Maintainer.Find(id);
            if (maitainer == null)
            {
                return HttpNotFound();
            }
            return View(maitainer);
        }

        // POST: Maitainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Maintainer maitainer = db.Maintainer.Find(id);
            db.Maintainer.Remove(maitainer);
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
