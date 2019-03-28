using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Vrijwilliger vrijwilliger = repo.GetVrijwilligerAccount(model.Username, model.Wachtwoord);
                if (vrijwilliger != null)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(vrijwilliger.Username, false);
                    //Setcookie
                    Session["loggedin_account"] = vrijwilliger;
                    return RedirectToAction("Index", "CMS");

                }
                else
                {
                    ModelState.AddModelError("Login-error", "yo shit wrong my dude");
                }
            }
            return View(model);
        }

        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
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

        //roept de salt en hash functies aan, stopt dit hashed password in de vrijwilliger. Stopt deze vrijwilliger in de database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Wachtwoord")] Vrijwilliger vrijwilliger)
        {
            if (ModelState.IsValid)
            {
                String salt = CreateSalt(10);
                String hashedPassword = GenerateSHA256Hash(vrijwilliger.Wachtwoord, salt);
                vrijwilliger.Wachtwoord = hashedPassword;
                repo.AddVrijwilliger(vrijwilliger);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrijwilliger);
        }

        //Maakt een array van bytes aan op basis van de size die hij meekrijgt. 
        public String CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);


        }

        //Maakt een byte array van de input en de Salt. En returned deze als string voor netheid. 
        public String GenerateSHA256Hash(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
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
