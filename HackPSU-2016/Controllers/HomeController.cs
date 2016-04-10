using HackPSU_2016.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HackPSU_2016.Controllers
{
    public class HomeController : Controller
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

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);

            var datum = new HomePageViewModel()
            {
                joinedGroups = user.Groups
                    .Where(gu => gu.DateApproved != null)
                    .Select(g => g.Group)
                    .OrderBy(g => g.Name)
                    .ToList(),
                potentialGroups = user.Groups
                    .Where(gu => gu.DateApproved == null)
                    .Take(10)
                    .Select(g => g.Group)
                    .OrderBy(g => g.Name)
                    .ToList()
            };

            return View(datum);
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
    }
}