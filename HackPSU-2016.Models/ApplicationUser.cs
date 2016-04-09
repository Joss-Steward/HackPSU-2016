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
        CrapSack = 1,
        AwesomeSauce = 2
    }

    public enum Playstyle
    {
        Casual = 1,
        UberHardcoreBro = 2
    }

    public enum CommunicationsPlatform
    {
        Mumble = 1,
        Steam = 2,
        TeamSpeak = 4
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
        }


        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<UsersToGroups> Groups { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public Skill Skill { get; set; }
        public Playstyle Playstyle { get; set; }
        public CommunicationsPlatform CommunicationsPlatform { get; set; }

        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTill { get; set; }
    }
}
