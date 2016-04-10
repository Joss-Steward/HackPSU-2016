using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackPSU_2016.Models
{
    public enum NotificationType
    {
        NewMessage,
        NewGroup
    }

    public class Notification
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public NotificationType NotificationType { get; set; }

        public DateTime? TimeSent { get; set; }
        public DateTime? TimeDismissed { get; set; }
    }
}
