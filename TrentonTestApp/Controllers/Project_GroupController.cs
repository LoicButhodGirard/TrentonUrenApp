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
    public class Project_GroupController : Controller
    {
        private TrentonTestEntities2 db = new TrentonTestEntities2();

        // GET: Project_Group
        public ActionResult Index()
        {
            var project_Group = db.Project_Group.Include(p => p.Project).Include(p => p.User);
            return View(project_Group.ToList());
        }

        // GET: Project_Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Group project_Group = db.Project_Group.Find(id);
            if (project_Group == null)
            {
                return HttpNotFound();
            }
            return View(project_Group);
        }

        // GET: Project_Group/Create
        public ActionResult Create()
        {
            ViewBag.project_group1 = new SelectList(db.Projects, "id", "name");
            ViewBag.user_group = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Project_Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,project_group1,user_group")] Project_Group project_Group)
        {
            if (ModelState.IsValid)
            {
                db.Project_Group.Add(project_Group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.project_group1 = new SelectList(db.Projects, "id", "name", project_Group.project_group1);
            ViewBag.user_group = new SelectList(db.Users, "id", "name", project_Group.user_group);
            return View(project_Group);
        }

        // GET: Project_Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Group project_Group = db.Project_Group.Find(id);
            if (project_Group == null)
            {
                return HttpNotFound();
            }
            ViewBag.project_group1 = new SelectList(db.Projects, "id", "name", project_Group.project_group1);
            ViewBag.user_group = new SelectList(db.Users, "id", "name", project_Group.user_group);
            return View(project_Group);
        }

        // POST: Project_Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,project_group1,user_group")] Project_Group project_Group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_Group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.project_group1 = new SelectList(db.Projects, "id", "name", project_Group.project_group1);
            ViewBag.user_group = new SelectList(db.Users, "id", "name", project_Group.user_group);
            return View(project_Group);
        }

        // GET: Project_Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Group project_Group = db.Project_Group.Find(id);
            if (project_Group == null)
            {
                return HttpNotFound();
            }
            return View(project_Group);
        }

        // POST: Project_Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project_Group project_Group = db.Project_Group.Find(id);
            db.Project_Group.Remove(project_Group);
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
