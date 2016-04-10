using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPSU_2016.Models
{
    public class HomePageViewModel
    {
        public List<Group> joinedGroups;
        public List<Group> potentialGroups;
    }

    public class ChatMessageViewModel
    {
        public DateTime Time;
        public string Sender;
        public string Text;
    }
}