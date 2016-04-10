using HackPSU_2016.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HackPSU_2016.Controllers
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Notifications
        [Authorize]
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var result = from applicationUsers in db.Users where applicationUsers.Id == id select applicationUsers.Notifications;
            var results = result.ToList();
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public List<Notification> GetNotifications(){
            //var id = User.Identity.GetUserId();
            //MembershipUser membershipUser = Membership.GetUser();
            //var id = membershipUser.ProviderUserKey.ToString();
            ApplicationUser user = UserManager.FindByName(User.Identity.Name);
            var result = from applicationUsers in db.Users where applicationUsers.Id == user.Id select applicationUsers.Notifications;
            List<Notification> notifications = result.Cast<Notification>().ToList();
            return notifications;
        }

        // GET: Notifications/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notifications/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notifications/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notifications/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notifications/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notifications/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
