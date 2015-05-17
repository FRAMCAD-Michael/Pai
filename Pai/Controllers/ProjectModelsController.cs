using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pai.Models;

namespace Pai.Controllers
{
    public class ProjectModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectModels
        public ActionResult Index()
        {
            return View(db.ProjectModels.ToList());
        }

        // GET: ProjectModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // GET: ProjectModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectName,ProjectStatus,ProjectOwner,CreatedOn")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.ProjectModels.Add(projectModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectModel);
        }

        // GET: ProjectModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: ProjectModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectName,ProjectStatus,ProjectOwner,CreatedOn")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectModel);
        }

        // GET: ProjectModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: ProjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProjectModel projectModel = db.ProjectModels.Find(id);
            db.ProjectModels.Remove(projectModel);
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
