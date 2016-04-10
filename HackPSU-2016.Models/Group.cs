using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackPSU_2016.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UsersToGroups> Members { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
