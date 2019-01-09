using ProjectWebApplicatie.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Jazz()
        {
            return View("~/Views/CMS/Jazz/Jazz.cshtml");
        }

        [Authorize]
        public ActionResult EditJazzPage()
        {
            return View("~/Views/CMS/Jazz/EditJazzPage.cshtml");
        }

        [Authorize]
        public ActionResult EditJazzSchedule()
        {
            return View("~/Views/CMS/Jazz/EditJazzSchedule.cshtml");
        }

        [Authorize]
        public ActionResult ViewJazzSales(int id)
        {
            return View("~/Views/CMS/Jazz/ViewJazzSales.cshtml");



        }



        [Authorize]
        public ActionResult Food()
        {
            return View("~/Views/CMS/Food/Food.cshtml");
        }

        [Authorize]
        public ActionResult ViewFoodSales()
        {
            return View("~/Views/CMS/Food/ViewFoodSales.cshtml");
        }

        [Authorize]
        public ActionResult EditFoodRestaurants()
        {
            return View("~/Views/CMS/Food/EditFoodRestaurants.cshtml");
        }

        [Authorize]
        public ActionResult EditFoodPage()
        {
            return View("~/Views/CMS/Food/EditFoodPage.cshtml");
        }

        [Authorize]
        public ActionResult Dance()
        {
            return View("~/Views/CMS/Dance/Dance.cshtml");
        }

        [Authorize]
        public ActionResult ViewDanceSales()
        {
            List<Dance> Dances = new List<Dance>();
            return View(("~/Views/CMS/Dance/ViewDanceSales.cshtml"), Dances);
        }

        [Authorize]
        public ActionResult EditDanceSchedule()
        {
            return View("~/Views/CMS/Dance/EditDanceSchedule.cshtml");
        }

        [Authorize]
        public ActionResult EditDancePage()
        {
            return View("~/Views/CMS/Dance/EditDancePage.cshtml");
        }

        [Authorize]
        public ActionResult Historic()
        {
            return View("~/Views/CMS/Historic/Historic.cshtml");
        }

        [Authorize]
        public ActionResult ViewHistoricSales()
        {
            return View("~/Views/CMS/Historic/ViewHistoricSales.cshtml");
        }

        [Authorize]
        public ActionResult EditHistoricSchedule()
        {
            return View("~/Views/CMS/Historic/EditHistoricSchedule.cshtml");
        }

        [Authorize]
        public ActionResult EditHistoricPage()
        {
            return View("~/Views/CMS/Historic/EditHistoricPage.cshtml");
        }




    }
}