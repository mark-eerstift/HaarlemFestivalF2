using ProjectWebApplicatie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ProjectWebApplicatie.Controllers
{
    public class CMSController : Controller
    {

        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();
        // GET: CMS
        [Authorize]
        // GET: CMSTest
        public ActionResult Index()
        {
            return View("~/Views/CMS/Index.cshtml", db.Evenements.ToList());
        }

        // GET: CMSTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // GET: CMSTest/Create
        public ActionResult Create()
        {
            return View("~/Views/CMS/Dance/Create.cshtml");
        }

        // POST: CMSTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvenementID,Locatie,BeginTijd,EindTijd,TicketsTotaal,TicketsVerkocht,EvenementPrijs")] Evenement evenement, Dance dance, Jazz jazz, History history, Food food)
        {
            if (ModelState.IsValid)
            {
                dance.EvenementID = evenement.EvenementID;
                jazz.EvenementID = evenement.EvenementID;
                history.EvenementID = evenement.EvenementID;
                food.EvenementID = evenement.EvenementID;

                db.Evenements.Add(dance);
                db.Evenements.Add(jazz);
                db.Evenements.Add(history);
                db.Evenements.Add(food);
                db.SaveChanges();
                
            }

            return View("~/Views/CMS/Dance/ViewDanceSales.cshtml", db.Evenements.ToList());
        }

        // GET: CMSTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // POST: CMSTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvenementID,Locatie,BeginTijd,EindTijd,TicketsTotaal,TicketsVerkocht,EvenementPrijs")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evenement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evenement);
        }

        // GET: CMSTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // POST: CMSTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evenement evenement = db.Evenements.Find(id);
            db.Evenements.Remove(evenement);
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

       /* Ik heb hier overwogen om hier twee methodes van te maken.
        * Maar ik weet niet zo goed hoe ik het beste deze methode door kan geven welk type event hij op moet halen. 
        * Mijn pogingen om dit voor elkaar te krijgen werden al snel erg lelijk. 
        * */
        [Authorize]
        public ActionResult ViewDanceSales()
        {
            List<Dance> dances = new List<Dance>();
            dances = db.Dances.ToList();
            
            return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
        }






        [Authorize]
        public ActionResult ViewDanceSalesByDate(DateTime date)
        {
            List<Dance> dances = new List<Dance>();
            dances = db.Dances.ToList();
            dances.RemoveAll(Dance => Dance.BeginTijd.Date != date.Date);

            return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
        }


        //Maakt in de desbetreffende view een Null object aan van de benodigde event. Checkt of de event null is en zo ja, laadt de pagina.
        [Authorize]
        public ActionResult ViewEventSales(Dance dance, Jazz jazz, History history, Food food)
        {
            if (dance == null)
            {
                List<Dance> dances = db.Dances.ToList();
                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (jazz == null)
            {
                List<Jazz> jazzs = db.Jazzs.ToList();
                return View(("~/Views/CMS/Dance/ViewJazzSales.cshtml"), jazzs);
            }
            else if (history == null)
            {
                List<History> histories = db.Historys.ToList();
                return View(("~/Views/CMS/Dance/ViewHistorySales.cshtml"), histories);
            }
            else if (food == null)
            {
                List<Food> foods = db.Foods.ToList();
                return View(("~/Views/CMS/Dance/ViewFoodSales.cshtml"), foods);
            }


            return View("~/Views/CMS/Index.cshtml");
        }
            
        


















        [Authorize]
        public ActionResult ViewJazzSales()
        {
            List<Jazz> jazz = new List<Jazz>();
            jazz = db.Jazzs.ToList();

            return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), jazz);
        }


        [Authorize]
        public ActionResult ViewJazzSalesByDate(DateTime date)
        {
            List<Jazz> jazz = new List<Jazz>();
            jazz = db.Jazzs.ToList();
            jazz.RemoveAll(Jazz => Jazz.BeginTijd.Date != date.Date);

            return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), jazz);
        }






    }
}