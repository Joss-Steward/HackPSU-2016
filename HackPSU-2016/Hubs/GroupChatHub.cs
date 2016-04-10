using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using HackPSU_2016.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HackPSU_2016.Hubs
{
    [Authorize]
    public class GroupChatHub : Hub
    {
        public void SendChatMessage(int groupId, string message)
        {
            var name = Context.User.Identity.Name;
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == name);

                if(user != null)
                {
                    var group = user.Groups.FirstOrDefault(g => g.Group.GroupId == groupId)?.Group;

                    if(group != null)
                    {
                        group.ChatMessages.Add(
                            new ChatMessage()
                            {
                                MessageText = message,
                                Sender = user,
                                MessageTime = DateTime.Now
                            });

                        foreach(var member in group.Members.Select(m => m.User))
                        {
                            db.Entry(member)
                                .Collection(u => u.Connections)
                                .Query()
                                .Where(c => c.Connected == true)
                                .Load();

                            if (member.Connections != null)
                            {
                                foreach (var connection in user.Connections)
                                {
                                    Clients.Client(connection.ConnectionID)
                                        .addChatMessage(name, message);
                                }
                            }
                        }

                    }
                }
            }
        }

        public override Task OnConnected()
        {
            var name = Context.User.Identity.Name;
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users
                    .Include(u => u.Connections)
                    .SingleOrDefault(u => u.UserName == name);

                user.Connections.Add(new Connection
                {
                    ConnectionID = Context.ConnectionId,
                    UserAgent = Context.Request.Headers["User-Agent"],
                    Connected = true
                });
                db.SaveChanges();
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            using (var db = new ApplicationDbContext())
            {
                var connection = db.Connections.Find(Context.ConnectionId);
                connection.Connected = false;
                db.SaveChanges();
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}