﻿using ProjectWebApplicatie.Models;
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

        //TO DO:
        //Datetime picker voor begin en eindtijd. 
        //De TicketsAvailable variable moet automatisch op Ticketstotaal – Ticketsverkocht gezet worden. 
        //Check of datetime binnen festival falt
        //Check of eindtijd niet eerder is dan begintijd.

        //Ontvangt 1 van de 4 event types, checkt of het model klopt en voegt deze dan toe aan de database.
        //Nog te doen: Checken of een event aan bestaat op basis van Locatie en Begin/eindtijd. 
        //Zo ja: There is an event called X at location Y at time Z.
        //Een nettere manier zou zijn een List<Evenementen> mee te geven vanuit de view. 

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
                if (CheckIfDuplicateEvent(d) == null)
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



            //else if (j.Events.EventSoort == "Jazz" && ModelState.IsValid)
            //{
            //    if (!CheckIfDuplicateEvent(j))
            //    {
            //        db.Evenements.Add(j);
            //        db.SaveChanges();
                    
            //        return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = j.Events.EventSoort });
            //    }
            //    else
            //    {
            //        TempData["j"] = j;
            //        TempData["error"] = "The following event overlaps with the event you are trying to add: ";
            //        return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = j.Events.EventSoort });
            //    }
            //}

            //if (f.Events.EventSoort == "Food" && ModelState.IsValid)
            //{
            //    if (!CheckIfDuplicateEvent(f))
            //    {
            //        db.Evenements.Add(f);
            //        db.SaveChanges();
            //        return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = f.Events.EventSoort });
            //    }
            //    else
            //    {
            //        TempData["f"] = f;
            //        TempData["error"] = "The following event overlaps with the event you are trying to add: ";
            //        return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = f.Events.EventSoort });
            //    }
            //}

            //else if (h.Events.EventSoort == "History" && ModelState.IsValid)
            //{
            //    if (!CheckIfDuplicateEvent(h))
            //    {
            //        db.Evenements.Add(h);
            //        db.SaveChanges();
            //        return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = h.Events.EventSoort });
            //    }
            //    else
            //    {
            //        TempData["h"] = h;
            //        TempData["error"] = "The following event overlaps with the event you are trying to add: ";
            //        return RedirectToAction("ViewEventSales", "CMS", new { eventSoort = h.Events.EventSoort });
            //    }
            //}

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

            return null;
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
        public ActionResult ViewEventSales(Evenement e, string Eventsoort)
        {
            
            
            if (Eventsoort == "Dance")
            {

                List<Dance> dances = db.Dances.ToList();
                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (Eventsoort == "Jazz")
            {
                List<Jazz> jazzs = db.Jazzs.ToList();
                return View(("~/Views/CMS/Jazz/ViewJazzSales.cshtml"), jazzs);
            }
            else if (Eventsoort == "History")
            {
                List<History> histories = db.Historys.ToList();
                return View(("~/Views/CMS/Historic/ViewHistorySales.cshtml"), histories);
            }
            else if (Eventsoort == "Food")
            {
                List<Food> foods = db.Foods.ToList();
                return View(("~/Views/CMS/Food/ViewFoodSales.cshtml"), foods);
            }


            return View("~/Views/CMS/Index.cshtml");
        }

        
        //Krijgt vanuit de benodigde event een Eventtype en datum mee, haalt alles van dat type en die datum op, en toont de juiste view.
        [Authorize]
        public ActionResult ViewEventSalesByDate(Evenement e, DateTime date, string Eventsoort)
        {
            if (Eventsoort == "Dance")
            {
                List<Dance> dances = new List<Dance>();
                dances = db.Dances.ToList();
                dances.RemoveAll(Dance => Dance.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), dances);
            }
            else if (Eventsoort == "Jazz")
            {
                List<Jazz> jazzs = new List<Jazz>();
                jazzs = db.Jazzs.ToList();
                jazzs.RemoveAll(Jazz => Jazz.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Jazz/ViewJazzSales.cshtml"), jazzs);
            }
            else if (Eventsoort == "History")
            {
                List<History> histories = new List<History>();
                histories = db.Historys.ToList();
                histories.RemoveAll(History => History.BeginTijd.Date != date.Date);

                return View(("~/Views/CMS/Historic/ViewHistorySales.cshtml"), histories);
            }
            else if (Eventsoort == "Food")
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

       



    }
}