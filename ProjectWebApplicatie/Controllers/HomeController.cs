using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWebApplicatie.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Food()
        {
            ViewBag.Message = "The history page.";

            return View();
        }
    }
}