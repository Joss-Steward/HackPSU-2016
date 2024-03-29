﻿using HackPSU_2016.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackPSU_2016.Controllers
{
    public class GroupController : Controller
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

        // GET: Group
        public ActionResult Details(int id)
        {
            var group = db.Groups.FirstOrDefault(g => g.GroupId == id);

            if (group != null)
            {
                var messages = group.ChatMessages
                    .OrderByDescending(c => c.MessageTime)
                    .Take(20)
                    .ToList();

                messages.Reverse();

                ViewBag.ChatMessages = messages.Select(m => new ChatMessageViewModel
                {
                    Sender = m.UserName,
                    Time = m.MessageTime ?? DateTime.Now,
                    Text = m.MessageText
                });
            }
            return View(group);
        }
    }
}