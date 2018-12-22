using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectWebApplicatie.Models;
using ProjectWebApplicatie.Repositories;

namespace ProjectWebApplicatie.Controllers
{
    public class LoginController : Controller
    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();
        private ILoginRepository repo = new LoginRepository();

        // GET: Login
        public ActionResult Index()
        {
            return View(repo.GetVrijWilligersListDb());
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vrijwilliger vrijwilliger = repo.GetVrijwilliger(id);
            if (vrijwilliger == null)
            {
                return HttpNotFound();
            }
            return View(vrijwilliger);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Wachtwoord")] Vrijwilliger vrijwilliger)
        {
            if (ModelState.IsValid)
            {
                repo.AddVrijwilliger(vrijwilliger);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrijwilliger);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vrijwilliger vrijwilliger = repo.GetVrijwilliger(id);
            if (vrijwilliger == null)
            {
                return HttpNotFound();
            }
            return View(vrijwilliger);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Wachtwoord")] Vrijwilliger vrijwilliger)
        {
            if (ModelState.IsValid)
            {
                repo.Entry(vrijwilliger);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrijwilliger);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vrijwilliger vrijwilliger = repo.GetVrijwilliger(id);
            if (vrijwilliger == null)
            {
                return HttpNotFound();
            }
            return View(vrijwilliger);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vrijwilliger vrijwilliger = repo.GetVrijwilliger(id);
            repo.RemoveVrijwilliger(vrijwilliger);
            repo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
