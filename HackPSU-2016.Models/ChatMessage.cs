using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackPSU_2016.Models
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        
        public ApplicationUser Sender { get; set; }
        public Group Group { get; set; }

        public string MessageText { get; set; }

        /* ENTITY FRAMEWORK BEING PAIN.
            NEED WORK NOW.
            THIS MAKE WORK */
        public string UserName { get; set; }
        public DateTime? MessageTime { get; set; }
    }
}
