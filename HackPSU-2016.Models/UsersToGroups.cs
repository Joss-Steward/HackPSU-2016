using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackPSU_2016.Models
{
    public class UsersToGroups
    {
        public int UsersToGroupsId { get; set; }

        [Key, Column(Order = 0)]
        public virtual ApplicationUser User { get; set; }

        [Key, Column(Order = 1)]
        public virtual Group Group { get; set; }

        public DateTime DateApproved { get; set; }
    }
}
