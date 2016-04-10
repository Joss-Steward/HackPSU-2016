using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace HackPSU_2016.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<UsersToGroups> UsersToGroups { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        //public System.Data.Entity.DbSet<HackPSU_2016.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}