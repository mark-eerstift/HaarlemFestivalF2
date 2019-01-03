using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Controllers
{
    public class DancesController : Controller
    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        // GET: Dances
        public ActionResult Index()
        {
            return View(db.Dances.ToList());
        }

        // GET: Dances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dance dance = db.Dances.Find(id);
            if (dance == null)
            {
                return HttpNotFound();
            }
            return View(dance);
        }

        // GET: Dances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvenementID,Locatie,BeginTijd,EindTijd,TicketsTotaal,TicketsVerkocht,Session,Artiest")] Dance dance)
        {
            if (ModelState.IsValid)
            {
                db.Evenements.Add(dance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dance);
        }

        // GET: Dances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dance dance = db.Dances.Find(id);
            if (dance == null)
            {
                return HttpNotFound();
            }
            return View(dance);
        }

        // POST: Dances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvenementID,Locatie,BeginTijd,EindTijd,TicketsTotaal,TicketsVerkocht,Session,Artiest")] Dance dance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dance);
        }

        // GET: Dances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dance dance = db.Dances.Find(id);
            if (dance == null)
            {
                return HttpNotFound();
            }
            return View(dance);
        }

        // POST: Dances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dance dance = db.Dances.Find(id);
            db.Evenements.Remove(dance);
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
