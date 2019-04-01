using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Controllers
{
    public class HomeController : Controller
    {
        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dance()
        {
            ViewBag.Message = "The dance page.";

            return View();
        }

        public ActionResult Historic()
        {
            ViewBag.Message = "The history page.";

            return View();
        }

        public ActionResult Timetable()
        {
            ViewBag.Message = "Page with a timetable";

            return View(db.Orders.ToList());
        }

        public ActionResult Food()
        {
            ViewBag.Message = "The main food page";

            return View();
        }

        public ActionResult FoodPurchase()
        {
            ViewBag.Message = "The food purchase page";

            return View();
        }
    }
}