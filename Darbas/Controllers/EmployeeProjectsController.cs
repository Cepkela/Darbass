using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Darbas.Models;

namespace Darbas.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: EmployeeProjects
        public ActionResult Index()
        {
            var employeeProject = db.EmployeeProject.Include(e => e.Employee).Include(e => e.Project);
            return View(employeeProject.ToList());
        }

        // GET: EmployeeProjects/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName");
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,ProjectId,Id")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                employeeProject.Id++;
                db.EmployeeProject.Add(employeeProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "EmployeeName", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Project, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProject.SingleOrDefault(m => m.Id == id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeProject employeeProject = db.EmployeeProject.SingleOrDefault(m => m.Id == id);
            db.EmployeeProject.Remove(employeeProject);
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
