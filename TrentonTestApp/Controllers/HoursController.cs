using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrentonTestApp;

namespace TrentonTestApp.Controllers
{
    public class HoursController : Controller
    {
        private TrentonTestEntities2 db = new TrentonTestEntities2();

        // GET: Hours
        public ActionResult Index()
        {
            var hours = db.Hours.Include(h => h.Project).Include(h => h.status).Include(h => h.User);
            return View(hours.ToList());
        }

        // GET: Hours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = db.Hours.Find(id);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // GET: Hours/Create
        public ActionResult Create()
        {
            ViewBag.project_id = new SelectList(db.Projects, "id", "name");
            ViewBag.status_id = new SelectList(db.status, "id", "status1");
            ViewBag.user_id = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,hours,date,user_id,project_id,status_id")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                db.Hours.Add(hour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_id = new SelectList(db.Projects, "id", "name", hour.project_id);
            ViewBag.status_id = new SelectList(db.status, "id", "status1", hour.status_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", hour.user_id);
            return View(hour);
        }

        // GET: Hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = db.Hours.Find(id);
            if (hour == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_id = new SelectList(db.Projects, "id", "name", hour.project_id);
            ViewBag.status_id = new SelectList(db.status, "id", "status1", hour.status_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", hour.user_id);
            return View(hour);
        }

        // POST: Hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hours,date,user_id,project_id,status_id")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_id = new SelectList(db.Projects, "id", "name", hour.project_id);
            ViewBag.status_id = new SelectList(db.status, "id", "status1", hour.status_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", hour.user_id);
            return View(hour);
        }

        // GET: Hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = db.Hours.Find(id);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // POST: Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hour hour = db.Hours.Find(id);
            db.Hours.Remove(hour);
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
