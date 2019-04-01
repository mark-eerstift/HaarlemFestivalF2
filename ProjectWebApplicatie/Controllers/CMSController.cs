using ProjectWebApplicatie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectWebApplicatie.Repositories;
using System.Web.UI;

namespace ProjectWebApplicatie.Controllers
{
    public class CMSController : Controller
    {

        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();
        private IEvenementsRepository repo = new EvenementsRepository();
        [Authorize]
        



        //Wat ik wil doen: 
        //Op het moment dat er op een link in de index word geklikt, word er een 
        
        public ActionResult Index()
        {
            Evenement e = new Evenement();
            
            return View("~/Views/CMS/Index.cshtml", e);
        }

       

        //Word aangeroepen wanneer er op Create x event word gedrukt en roept de juiste view aan.
        public ActionResult Create(string Eventsoort)
        {

            if (Eventsoort == "Dance")
            {
               
                Evenement d = new Dance();
                
                return View(("~/Views/CMS/Dance/Create.cshtml" ), d);
            }
            else if (Eventsoort == "Jazz")
            {
                Evenement j = new Jazz();
                return View(("~/Views/CMS/Jazz/Create.cshtml"),j);
            }
            else if (Eventsoort == "History")
            {
                Evenement h = new History();
                return View(("~/Views/CMS/Historic/Create.cshtml"), h);
            }
            else if (Eventsoort == "Food")
            {
                Evenement f = new Food();
                return View(("~/Views/CMS/Food/Create.cshtml"), f);
            }


            return View("~/Views/CMS/Index.cshtml");
        }

     
        //Error message voor de event
        public ActionResult ModalPopUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dance d, Food f, History h, Jazz j)
        {




            if (d.Events.EventSoort == "Dance" && ModelState.IsValid)
            {
                

                Dance duplicate = (Dance)repo.GetChildByParent(CheckIfDuplicateEvent(d));
                IEnumerable<Evenement> dances = repo.GetDanceObject(duplicate);
                if (duplicate == null)
                {

                    db.Evenements.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = d.Events.EventSoort });
                }
                else
                {
                    string artiestnaam = duplicate.Artiest.Naam;
                    TempData["artiest"] = artiestnaam;
                    
                    return View("ModalPopUp", dances);

                }
            }

            if (d.Events.EventSoort == "Dance" && ModelState.IsValid)
            {


                Dance duplicate = (Dance)repo.GetChildByParent(CheckIfDuplicateEvent(d));
                if (duplicate == null)
                {

                    db.Evenements.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = d.Events.EventSoort });
                }
                else
                {
                    TempData["artiest"] = duplicate.Artiest.Naam;
                    TempData["begintijd"] = duplicate.BeginTijd;
                    TempData["eindtijd"] = duplicate.EindTijd;
                    TempData["locatie"] = duplicate.Locatie;
                    TempData["dupeEventID"] = duplicate.EvenementID;
                    TempData["dupeEvent"] = duplicate;
                    TempData["error"] = "The following event overlaps with the event you are trying to add: ";
                    return PartialView("ModalPopUp");

                }
            }

            if (d.Events.EventSoort == "Dance" && ModelState.IsValid)
            {


                Dance duplicate = (Dance)repo.GetChildByParent(CheckIfDuplicateEvent(d));
                if (duplicate == null)
                {

                    db.Evenements.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = d.Events.EventSoort });
                }
                else
                {
                    TempData["artiest"] = duplicate.Artiest;
                    TempData["begintijd"] = duplicate.BeginTijd;
                    TempData["eindtijd"] = duplicate.EindTijd;
                    TempData["locatie"] = duplicate.Locatie;
                    TempData["dupeEventID"] = duplicate.EvenementID;
                    TempData["dupeEvent"] = duplicate;
                    TempData["error"] = "The following event overlaps with the event you are trying to add: ";
                    return PartialView("ModalPopUp");

                }
            }

            if (d.Events.EventSoort == "Dance" && ModelState.IsValid)
            {


                Dance duplicate = (Dance)repo.GetChildByParent(CheckIfDuplicateEvent(d));
                IEnumerable<Evenement> dances = repo.GetDanceObject(duplicate);
                
                if (duplicate == null)
                {

                    db.Evenements.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = d.Events.EventSoort });
                }
                else
                {
                    TempData["artiest"] = duplicate.Artiest;
                    TempData["begintijd"] = duplicate.BeginTijd;
                    TempData["eindtijd"] = duplicate.EindTijd;
                    TempData["locatie"] = duplicate.Locatie;
                    TempData["dupeEventID"] = duplicate.EvenementID;
                    TempData["dupeEvent"] = duplicate;
                    TempData["error"] = "The following event overlaps with the event you are trying to add: ";
                    return PartialView("ModalPopUp", dances);

                }
            }




            //Uitvogelen wat hier een logischere return statement is.
            //Vragen: Meer events toevoegen of naar rooster toe ?

            return View();
        }


        //Controleert of er al een event is op dat precieze tijdstip en locatie.
        //te doen: Eindtijd - begintijd, checken of het evenement dat je wilt toevoegen BEGINT tijdens een ander event. 
        [HttpPost]
        public Evenement CheckIfDuplicateEvent(Evenement e)
        {
            List<Evenement> evenements = db.Evenements.ToList();
            foreach(Evenement x in evenements)
            {
                //Checkt voor een toegevoegd event of er al een event is op die tijd en locatie. 
                if(e.BeginTijd == x.BeginTijd && e.EindTijd == x.EindTijd && e.Locatie == x.Locatie)
                {
                   
                    return x;
                }

                //Checkt of de begintijd van een event op locatie X TIJDENS een ander event is op die locatie. Ofwel, checkt voor overlap.
                else if (e.Locatie == x.Locatie && e.BeginTijd.TimeOfDay > x.BeginTijd.TimeOfDay && e.BeginTijd.TimeOfDay < x.EindTijd.TimeOfDay)
                {
                    return x;
                }

            }

            return e;
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

            if (evenement.Events.EventSoort == "Dance")
            {

                IEnumerable<Dance>dances = repo.GetDanceObject(evenement);
                Dance d = dances.First();
                return View(("~/Views/CMS/Dance/Edit.cshtml"), d);
            }
            else if (evenement.Events.EventSoort == "Jazz")
            {
                Evenement j = new Jazz();
                return View(("~/Views/CMS/Jazz/Edit.cshtml"), j);
            }
            else if (evenement.Events.EventSoort == "History")
            {
                Evenement h = new History();
                return View(("~/Views/CMS/Historic/Edit.cshtml"), h);
            }
            else if (evenement.Events.EventSoort == "Food")
            {
                Evenement f = new Food();
                return View(("~/Views/CMS/Food/Edit.cshtml"), f);
            }


            return View("~/Views/CMS/Index.cshtml");
        }

        // POST: CMSTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evenement e)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(("~/Views/CMS/Dance/ViewDanceEvents.cshtml"), e);
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


            switch (evenement.Events.EventSoort)
            {
                case "Dance":
                    
                    
                    IEnumerable<Dance> danceObject = repo.GetDanceObject(evenement);

                    return View(("~/Views/CMS/Dance/Delete.cshtml"), danceObject);


                case "Jazz":
                    IEnumerable<Jazz> jazzObject = repo.GetJazzObject(evenement);

                    return View(("~/Views/CMS/Dance/Delete.cshtml"), jazzObject);

                case "History":
                    IEnumerable<History> historyObject = repo.GetHistoryObject(evenement);

                    return View(("~/Views/CMS/Dance/Delete.cshtml"), historyObject);
                case "Food":
                    IEnumerable<Food> foodObject = repo.GetFoodObject(evenement);

                    return View(("~/Views/CMS/Dance/Delete.cshtml"), foodObject);
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
            return RedirectToAction("~/Views/CMS/Dance/Index.cshtml");
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
        public ActionResult ViewEventSales(Evenement e)
        {
            
            
            if (e.Events.EventSoort == "Dance")
            {

                List<Dance> dances = db.Dances.ToList();
                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (e.Events.EventSoort == "Jazz")
            {
                List<Jazz> jazzs = db.Jazzs.ToList();
                return View(("~/Views/CMS/Jazz/ViewJazzSales.cshtml"), jazzs);
            }
            else if (e.Events.EventSoort == "History")
            {
                List<History> histories = db.Historys.ToList();
                return View(("~/Views/CMS/Historic/ViewHistorySales.cshtml"), histories);
            }
            else if (e.Events.EventSoort == "Food")
            {
                List<Food> foods = db.Foods.ToList();
                return View(("~/Views/CMS/Food/ViewFoodSales.cshtml"), foods);
            }


            return View("~/Views/CMS/Index.cshtml");
        }

        
        //Krijgt vanuit de benodigde event een Eventtype en datum mee, haalt alles van dat type en die datum op, en toont de juiste view.
        [Authorize]
        public ActionResult ViewEventSalesByDate(Evenement e, DateTime date)
        {
            if (e.Events.EventSoort == "Dance")
            {
                List<Dance> dances = new List<Dance>();
                dances = db.Dances.ToList();
                dances.RemoveAll(Dance => Dance.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (e.Events.EventSoort == "Jazz")
            {
                List<Jazz> jazzs = new List<Jazz>();
                jazzs = db.Jazzs.ToList();
                jazzs.RemoveAll(Jazz => Jazz.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Jazz/ViewJazzSales.cshtml"), jazzs);
            }
            else if (e.Events.EventSoort == "History")
            {
                List<History> histories = new List<History>();
                histories = db.Historys.ToList();
                histories.RemoveAll(History => History.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Historic/ViewHistorySales.cshtml"), histories);
            }
            else if (e.Events.EventSoort == "Food")
            {
                List<Food> foods = new List<Food>();
                foods = db.Foods.ToList();
                foods.RemoveAll(Food => Food.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Food/ViewFoodSales.cshtml"), foods);
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


        // Go to page of changing texts on a page
        [Authorize]
        public ActionResult ChangeTexts(Evenement e)
        {
            switch(e.Events.EventSoort)
            {
                case "dance":
                    return View("~/Views/CMS/Index.cshtml");
                case "historic":
                    return View("~/Views/CMS/Index.cshtml");
                case "food":
                    return View("~/Views/CMS/Index.cshtml");
                case "jazz":
                    return View("~/CMS/Jazz/ChangeTexts.cshtml");
                default:
                    return View("~/Views/CMS/Index.cshtml");
            }
        }
        // Go to page of changing images on a page
        [Authorize]
        public ActionResult ChangeImages(Evenement e)
        {
            switch (e.Events.EventSoort)
            {
                case "dance":
                    return View("~/Views/CMS/Index.cshtml");
                case "historic":
                    return View("~/Views/CMS/Index.cshtml");
                case "food":
                    return View("~/Views/CMS/Index.cshtml");
                case "jazz":
                    return View("~/CMS/Jazz/ChangeImages.cshtml");
                default:
                    return View("~/Views/CMS/Index.cshtml");
            }
        }

    }
}