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
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            Console.WriteLine("Application STARTING");

            //var host = new JobHost();
            //// The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
            Random rand = new Random();
            long groupCount = 0;

            while (true)
            {
                using (var db = new ApplicationDbContext())
                {
                    var group = new Group();
                    group.Name = "Group " + groupCount;

                    Console.WriteLine("Creating New Group");

                    db.Groups.Add(group);
                    db.SaveChanges();
                    
                    if(group != null)
                    {
                        Console.WriteLine("Created group " + "Group " + groupCount);

                        int usersAdded = 0;

                        foreach(ApplicationUser user in db.Users.ToList())
                        {
                            if (rand.Next(0, 10) <= 7)
                                continue;

                            Console.WriteLine("Added user {" + user.UserName + "} to group");

                            if(user.Groups.Where(g => g.DateApproved == null).Count() < 10)
                            {
                                try
                                {
                                    group = db.Groups.FirstOrDefault(g => g.Name == "Group " + groupCount);
                                    var u = db.Users.Where(un => un.UserName == user.UserName)
                                        .SingleOrDefault();

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
                                    throw;
                                }

                                usersAdded++;
                            }
                        }

                        db.SaveChanges();

                        if(usersAdded == 0) {
                            Console.WriteLine("Didn't add anyone, sleeping long time now");
                            Thread.Sleep(10000);
                        }
                    } else
                    {
                        Console.WriteLine("Failed to create group");
                    }
                    groupCount++;

                    Thread.Sleep(1000);
                }
            }

        }
    }
}
