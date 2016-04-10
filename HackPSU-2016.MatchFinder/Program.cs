using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Threading;
using HackPSU_2016.Models;
using System.Data.Entity.Validation;

namespace HackPSU_2016.MatchFinder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Starting match finding webjob...");

            Random random = new Random();
            long groupCount = 0;

            while (true)
            {
                Console.WriteLine("Generating new group");
                using (var db = new ApplicationDbContext())
                {
                    var GroupUsers = new List<ApplicationUser>();
                
                    foreach(ApplicationUser user in db.Users.ToList())
                    {
                        if (random.Next(0, 10) < 8) continue;
                        GroupUsers.Add(user);
                    }

                    if(GroupUsers.Count > 3)
                    {
                        var NewGroup = new Group()
                        {
                            Name = "Group " + groupCount
                        };

                        db.Groups.Add(NewGroup);
                        db.SaveChanges();

                        var group = db.Groups.FirstOrDefault(g => g.Name == "Group " + groupCount);

                        foreach (ApplicationUser user in GroupUsers)
                        {
                            try
                            {
                                if (group != null && user != null)
                                {
                                    UsersToGroups groupRelation = new UsersToGroups
                                    {
                                        User = user,
                                        Group = group,
                                        DateApproved = DateTime.Now
                                    };

                                    db.UsersToGroups.Add(groupRelation);
                                    db.SaveChanges();

                                    Console.WriteLine("Added {" + user.UserName + "} to {Group " + groupCount + "}");
                                }
                            }
                            catch (DbEntityValidationException e)
                            {
                                foreach (var eve in e.EntityValidationErrors)
                                {
                                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                                    foreach (var ve in eve.ValidationErrors)
                                    {
                                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                            ve.PropertyName, ve.ErrorMessage);
                                    }
                                }
                            }
                        }

                        groupCount++;
                    }
                }

                Thread.Sleep(10000);
            }
        }
    }
}
