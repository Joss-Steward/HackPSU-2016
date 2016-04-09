namespace HackPSU_2016.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HackPSU_2016.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HackPSU_2016.Models.ApplicationDbContext";
        }

        protected override void Seed(HackPSU_2016.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var AOE = new Game { Name = "Age of Empires II" };
            var BF2 = new Game { Name = "StarWars BattleFront II" };
            var WET = new Game { Name = "Wolfenstein Enemy Territory" };
            var SC2 = new Game { Name = "Starcraft II" };
            var CSGO = new Game { Name = "Counterstrike: Globally Offensive" };

            context.Games.AddOrUpdate(
                g => g.Name,
                new Game { Name = "Halo" },
                new Game { Name = "Flatout" },
                new Game { Name = "Quake" },
                new Game { Name = "BattleField 1942" },
                AOE,
                BF2,
                WET,
                SC2,
                CSGO
                );

            context.SaveChanges();

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");

            var jared = new ApplicationUser
            {
                Email = "user1@com.website",
                UserName = "redja",
                PasswordHash = password, // Default password seeding for testing purposes
                Games = { AOE, SC2 }
            };

            var ian = new ApplicationUser
            {
                Email = "user2@com.website",
                UserName = "kittyPurry",
                PasswordHash = password, // Default password seeding for testing purposes
                Games = { CSGO, BF2, AOE }
            };

            var joss = new ApplicationUser
            {
                Email = "user3@com.website",
                UserName = "Pr0metheus",
                PasswordHash = password, // Default password seeding for testing purposes
                Games = { BF2, AOE, CSGO, SC2 }
            };

            context.Users.AddOrUpdate(
                u => u.Email,
                jared, 
                ian, 
                joss
                );

            context.SaveChanges();

            var saucy = new Group
            {
                Name = "SaucyTomato"
            };

            context.Groups.AddOrUpdate(
                g => g.Name,
                saucy);

            context.SaveChanges();

            context.UsersToGroups.AddOrUpdate(
                ug => ug.UsersToGroupsId,
                new UsersToGroups
                {
                    User = jared,
                    Group = saucy
                },
                new UsersToGroups
                {
                    User = ian,
                    Group = saucy
                },
                new UsersToGroups
                {
                    User = joss,
                    Group = saucy
                });

            context.SaveChanges();

        }
    }
}
