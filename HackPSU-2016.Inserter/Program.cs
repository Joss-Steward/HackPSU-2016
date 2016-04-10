using HackPSU_2016.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInserter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\csuser\Downloads\allTheGames.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        while (sr.Peek() >= 0)
                        {
                            String GameName = sr.ReadLine();
                            String Name_ = GameName.Split('(')[0];

                            try
                            {
                                if (Name_ != null)
                                {
                                    db.Games.Add(new Game { Name = GameName });
                                    SaveChanges(db);
                                }
                            } catch(Exception e)
                            {
                                Console.WriteLine("Error thing -> '" + GameName + "' : '" + Name_ + "'");
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }


            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        private static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
