using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackPSU_2016.Models
{
    public class Game
    {
        public int GameId { get; set; }

        [Required]
        public int Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
