using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workforce_Monitor.Models;

namespace Workforce_Monitor.Controllers
{
    public class EmployeeController : Controller
    {
        private WorkforceMonitorDBEntities1 db = new WorkforceMonitorDBEntities1();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.TNEmpMasterTables.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TNEmpMasterTable tNEmpMasterTable = db.TNEmpMasterTables.Find(id);
            if (tNEmpMasterTable == null)
            {
                return HttpNotFound();
            }
            return View(tNEmpMasterTable);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_code,emp_name,designation,salary")] TNEmpMasterTable tNEmpMasterTable)
        {
            if (string.IsNullOrEmpty(tNEmpMasterTable.emp_code) )
            {
                ModelState.AddModelError("", "Employee Code is Required");
            }
            if (string.IsNullOrEmpty(tNEmpMasterTable.emp_name) )
            {
                ModelState.AddModelError("", "Employee Name is Required.");
            }
            if (string.IsNullOrEmpty(tNEmpMasterTable.designation) )
            {
                ModelState.AddModelError("", "Employee Designation is Required.");
            }
            if (ModelState.IsValid)
            {
                db.TNEmpMasterTables.Add(tNEmpMasterTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tNEmpMasterTable);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TNEmpMasterTable tNEmpMasterTable = db.TNEmpMasterTables.Find(id);
            if (tNEmpMasterTable == null)
            {
                return HttpNotFound();
            }
            return View(tNEmpMasterTable);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_code,emp_name,designation,salary")] TNEmpMasterTable tNEmpMasterTable)
        {
            if (string.IsNullOrEmpty(tNEmpMasterTable.emp_code))
            {
                ModelState.AddModelError("", "Employee Code is Required");
            }
            if (string.IsNullOrEmpty(tNEmpMasterTable.emp_name))
            {
                ModelState.AddModelError("", "Employee Name is Required.");
            }
            if (string.IsNullOrEmpty(tNEmpMasterTable.designation))
            {
                ModelState.AddModelError("", "Employee Designation is Required.");
            }
            if (ModelState.IsValid)
            {
                db.Entry(tNEmpMasterTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tNEmpMasterTable);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TNEmpMasterTable tNEmpMasterTable = db.TNEmpMasterTables.Find(id);
            if (tNEmpMasterTable == null)
            {
                return HttpNotFound();
            }
            return View(tNEmpMasterTable);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TNEmpMasterTable tNEmpMasterTable = db.TNEmpMasterTables.Find(id);
            db.TNEmpMasterTables.Remove(tNEmpMasterTable);
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
