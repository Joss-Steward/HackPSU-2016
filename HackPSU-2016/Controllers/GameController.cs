using HackPSU_2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackPSU_2016.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Game/get_suggestions/<text>
        [Route("Game/Suggest/{text}")]
        public ActionResult Suggest(string text)
        {
            var gameSuggestions = new
            {
                PartialName = text,
                Suggestions = db.Games
                .Where(g => g.Name.Contains(text))
                .OrderByDescending(g => g.Users.Count)
                .Take(10)
                .Select(g => new { Id = g.GameId, Name = g.Name})
                .ToList()
            };

            return Json(gameSuggestions, JsonRequestBehavior.AllowGet);
        }
    }
}