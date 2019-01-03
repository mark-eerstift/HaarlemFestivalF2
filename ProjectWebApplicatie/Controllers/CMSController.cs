using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectWebApplicatie.Controllers
{
    public class CMSController : Controller
    {
        // GET: CMS
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Jazz()
        {
            return View();
        }

        [Authorize]
        public ActionResult Food()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dance()
        {
            return View();
        }

        [Authorize]
        public ActionResult Historic()
        {
            return View();
        }


    }
}