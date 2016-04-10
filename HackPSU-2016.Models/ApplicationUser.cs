using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HackPSU_2016.Models
{
    public enum Skill
    {
        Brand_New = 1,
        Casual = 2,
        Veteran = 3,
        Professional = 4
    }

    public enum Playstyle
    {
        Casual = 1,
        Role_Play = 2,
        Trolling = 3,
        Competative = 4,
        Creative = 5,
        Entertainment = 6
    }

    public enum CommunicationsPlatform
    {
        Mumble = 1,
        Steam = 2,
        Skype = 3,
        TeamSpeak = 4
    }

    public class Availability
    {
        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Evening { get; set; }
        public bool Night { get; set; }
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
            this.Games = new HashSet<Game>();
            Sunday = new Availability();
            Monday    = new Availability();
            Tuesday   = new Availability();
            Wednesday = new Availability();
            Thursday  = new Availability();
            Friday    = new Availability();
            Saturday  = new Availability();
    }


        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<UsersToGroups> Groups { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public Skill Skill { get; set; }
        public Playstyle Playstyle { get; set; }
        public CommunicationsPlatform CommunicationsPlatform { get; set; }

        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTill { get; set; }

        public Availability Sunday { get; set; }
        public Availability Monday { get; set; }
        public Availability Tuesday { get; set; }
        public Availability Wednesday { get; set; }
        public Availability Thursday { get; set; }
        public Availability Friday { get; set; }
        public Availability Saturday { get; set; }
    }
}
