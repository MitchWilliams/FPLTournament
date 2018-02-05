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
    public class TournamentAssignmentsController : Controller
    {
        private FPLContext db = new FPLContext();

        // GET: TournamentAssignments
        public ActionResult Index()
        {
            var tournamentAssignments = db.TournamentAssignments.Include(t => t.team).Include(t => t.tournament);
            return View(tournamentAssignments.ToList());
        }

        // GET: TournamentAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentAssignment tournamentAssignment = db.TournamentAssignments.Find(id);
            if (tournamentAssignment == null)
            {
                return HttpNotFound();
            }
            return View(tournamentAssignment);
        }

        // GET: TournamentAssignments/Create
        public ActionResult Create(int? id)
        {
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "name");

            if (id != null)
            {
                var selectList = new List<SelectListItem>();

                selectList.Add(new SelectListItem
                {
                    Value = id.ToString(),
                    Text = db.Tournaments.Find(id).name
                });

                ViewBag.TournamentId = selectList;

            }
            else
            {
                ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "name");
            }
            
            return View();
        }

       

        // POST: TournamentAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TournamentAssignmentId,TournamentId,TeamId")] TournamentAssignment tournamentAssignment)
        {
            if (ModelState.IsValid)
            {
                db.TournamentAssignments.Add(tournamentAssignment);
                db.SaveChanges();
                return RedirectToAction("Index", "Tournament");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager", tournamentAssignment.TeamId);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "name", tournamentAssignment.TournamentId);
            return View(tournamentAssignment);
        }

        // GET: TournamentAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentAssignment tournamentAssignment = db.TournamentAssignments.Find(id);
            if (tournamentAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager", tournamentAssignment.TeamId);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "name", tournamentAssignment.TournamentId);
            return View(tournamentAssignment);
        }

        // POST: TournamentAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentAssignmentId,TournamentId,TeamId")] TournamentAssignment tournamentAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "manager", tournamentAssignment.TeamId);
            ViewBag.TournamentId = new SelectList(db.Tournaments, "TournamentId", "name", tournamentAssignment.TournamentId);
            return View(tournamentAssignment);
        }

        // GET: TournamentAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentAssignment tournamentAssignment = db.TournamentAssignments.Find(id);
            if (tournamentAssignment == null)
            {
                return HttpNotFound();
            }
            return View(tournamentAssignment);
        }

        // POST: TournamentAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TournamentAssignment tournamentAssignment = db.TournamentAssignments.Find(id);
            db.TournamentAssignments.Remove(tournamentAssignment);
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
