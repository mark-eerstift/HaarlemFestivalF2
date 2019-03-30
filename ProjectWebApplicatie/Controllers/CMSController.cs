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

        //Dance events kunnen aangemaaktt worden, code kopieeren voor andere 3 events.
        //Datetime picker voor begin en eindtijd. 

        //De TicketsAvailable variable moet automatisch op Ticketstotaal – Ticketsverkocht gezet worden. 
        //Date time picker voor begin en einddatum.

        //Ontvangt 1 van de 4 event types, checkt of het model klopt en voegt deze dan toe aan de database.
        //Een nettere manier zou zijn een List<Evenementen> mee te geven vanuit de view. 

            //Iets om te overwegen: Dance Jazz etc aan evenement te linken door middel van FK EvenementID

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dance dance, Jazz jazz, History history, Food food)
        {
            if (ModelState.IsValid)
            {
                db.Evenements.Add(dance);
                db.SaveChanges();               
            }

            else if (ModelState.IsValid)
            {
                db.Evenements.Add(jazz);
                db.SaveChanges();
            }

            else if (ModelState.IsValid)
            {
                db.Evenements.Add(history);
                db.SaveChanges();
            }

            else if (ModelState.IsValid)
            {
                db.Evenements.Add(food);
                db.SaveChanges();
            }

            //Uitvogelen wat hier een logischere return statement is. 
            //Vragen: Meer events toevoegen of naar rooster toe?
            return View("~/Views/CMS/Dance/Index.cshtml");
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

     
        //Haalt ALLE events op van een gegeven event-type
        //Krijgt vanuit de benodigde event een Eventtype mee, haalt alles van dat type op uit de database en toont de juiste view.
        [Authorize]
        public ActionResult ViewEventSales(string eventstring)
        {
            if (eventstring == "dance")
            {
                List<Dance> dances = db.Dances.ToList();
                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (eventstring == "jazz")
            {
                List<Jazz> jazzs = db.Jazzs.ToList();
                return View(("~/Views/CMS/Jazz/ViewJazzSales.cshtml"), jazzs);
            }
            else if (eventstring == "history")
            {
                List<History> histories = db.Historys.ToList();
                return View(("~/Views/CMS/Historic/ViewHistorySales.cshtml"), histories);
            }
            else if (eventstring == "food")
            {
                List<Food> foods = db.Foods.ToList();
                return View(("~/Views/CMS/Food/ViewFoodSales.cshtml"), foods);
            }


            return View("~/Views/CMS/Index.cshtml");
        }

        
        //Krijgt vanuit de benodigde event een Eventtype en datum mee, haalt alles van dat type en die datum op, en toont de juiste view.
        [Authorize]
        public ActionResult ViewEventSalesByDate(string eventstring, DateTime date)
        {
            if (eventstring == "dance")
            {
                List<Dance> dances = new List<Dance>();
                dances = db.Dances.ToList();
                dances.RemoveAll(Dance => Dance.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (eventstring == "jazz")
            {
                List<Jazz> jazzs = new List<Jazz>();
                jazzs = db.Jazzs.ToList();
                jazzs.RemoveAll(Jazz => Jazz.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Jazz/ViewJazzSales.cshtml"), jazzs);
            }
            else if (eventstring == "history")
            {
                List<History> histories = new List<History>();
                histories = db.Historys.ToList();
                histories.RemoveAll(History => History.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Historic/ViewHistorySales.cshtml"), histories);
            }
            else if (eventstring == "food")
            {
                List<Food> foods = new List<Food>();
                foods = db.Foods.ToList();
                foods.RemoveAll(Food => Food.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Food/ViewDanceSales.cshtml"), foods);
            }


            return View("~/Views/CMS/Index.cshtml");
        }


        
        //Toont de indexes van de verschillende event types. 
        [Authorize]
        public ActionResult Jazz()
        {
            return View("~/Views/CMS/Jazz/Index.cshtml");
        }

        [Authorize]
        public ActionResult Food()
        {
            return View("~/Views/CMS/Food/Index.cshtml");
        }

        [Authorize]
        public ActionResult Dance()
        {
            return View("~/Views/CMS/Dance/Index.cshtml");
        }

        [Authorize]
        public ActionResult Historic()
        {
            return View("~/Views/CMS/Historic/Index.cshtml");
        }


    }
}