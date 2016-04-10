using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackPSU_2016.Controllers{
    public class GroupController : Controller{

        public ActionResult Index(int? Id){
            return View();
        }
    }
}
