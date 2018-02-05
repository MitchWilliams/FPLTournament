using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPLCup.DAL;
using FPLTournament.Models;

namespace FPLCup.Controllers
{
    public class GroupAssignmentsController : Controller
    {
        private FPLContext db = new FPLContext();

        // GET: GroupAssignments
        public ActionResult Index()
        {
            var groupAssignments = db.GroupAssignments.Include(g => g.group).Include(g => g.team);
            return View(groupAssignments.ToList());
        }

        // GET: GroupAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupAssignment groupAssignment = db.GroupAssignments.Find(id);
            if (groupAssignment == null)
            {
                return HttpNotFound();
            }
            return View(groupAssignment);
        }

        // GET: GroupAssignments/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupId");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager");
            return View();
        }

        // POST: GroupAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupAssignmentId,TeamId,GroupId")] GroupAssignment groupAssignment)
        {
            if (ModelState.IsValid)
            {
                db.GroupAssignments.Add(groupAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupId", groupAssignment.GroupId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager", groupAssignment.TeamId);
            return View(groupAssignment);
        }

        // GET: GroupAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupAssignment groupAssignment = db.GroupAssignments.Find(id);
            if (groupAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupId", groupAssignment.GroupId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager", groupAssignment.TeamId);
            return View(groupAssignment);
        }

        // POST: GroupAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupAssignmentId,TeamId,GroupId")] GroupAssignment groupAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupId", groupAssignment.GroupId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager", groupAssignment.TeamId);
            return View(groupAssignment);
        }

        // GET: GroupAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupAssignment groupAssignment = db.GroupAssignments.Find(id);
            if (groupAssignment == null)
            {
                return HttpNotFound();
            }
            return View(groupAssignment);
        }

        // POST: GroupAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupAssignment groupAssignment = db.GroupAssignments.Find(id);
            db.GroupAssignments.Remove(groupAssignment);
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
