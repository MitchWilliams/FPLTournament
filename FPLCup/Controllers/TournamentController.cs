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
    public class TournamentController : Controller
    {
        private FPLContext db = new FPLContext();

        // GET: Tournament
        public ActionResult Index()
        {
            var tournaments = db.Tournaments.Include(t => t.groupStage);
            return View(tournaments.ToList());
        }

        // GET: Tournament/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournament/Create
        public ActionResult Create()
        {
            ViewBag.TournamentId = new SelectList(db.GroupStages, "GroupStageId", "GroupStageId");
            return View();
        }

        // POST: Tournament/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //Modify so that there's separate creates if there is a Group Stage or not
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TournamentId,name,isGroupTournament")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                if (tournament.isGroupTournament == true)
                {
                    GroupStage gs = new GroupStage();
                    tournament.groupStage = gs;
                }

                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TournamentId = new SelectList(db.GroupStages, "GroupStageId", "GroupStageId", tournament.TournamentId);
            return View(tournament);
        }

        // GET: Tournament/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            ViewBag.TournamentId = new SelectList(db.GroupStages, "GroupStageId", "GroupStageId", tournament.TournamentId);
            return View(tournament);
        }

        // POST: Tournament/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentId,name,isGroupTournament")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TournamentId = new SelectList(db.GroupStages, "GroupStageId", "GroupStageId", tournament.TournamentId);
            return View(tournament);
        }

        // GET: Tournament/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournaments.Find(id);
            db.Tournaments.Remove(tournament);
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
