using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AuditoriasCiudadanas.Hubs
{
    public class ChatHub : Hub
    {
        public static List<Client> ConnectedUsers { get; set; } = new List<Client>();

        public void Connect(string username)
        {
            if(ConnectedUsers.Any(u => u.Username.Equals(username))){
                ConnectedUsers.Remove(ConnectedUsers.First(u => u.Username.Equals(username)));
            }
            Client c = new Client()
            {
                Username = username,
                ID = Context.ConnectionId
            };
            ConnectedUsers.Add(c);
            Clients.All.updateUsers(ConnectedUsers.Count(), ConnectedUsers.Select(u => u.Username));

        }

        public void Send(string message, string idDestinatario)
        {
            var sender = ConnectedUsers.First(u => u.ID.Equals(Context.ConnectionId));
            var receiver = ConnectedUsers.First(u => u.Username.Equals(idDestinatario));
            Clients.Client(receiver.ID).broadcastMessage(sender.Username, message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var disconnectedUser = ConnectedUsers.FirstOrDefault(c => c.ID.Equals(Context.ConnectionId));
            ConnectedUsers.Remove(disconnectedUser);
            Clients.All.updateUsers(ConnectedUsers.Count(), ConnectedUsers.Select(u => u.Username));
            return base.OnDisconnected(stopCalled);
        }
    }

    public class Client
    {
        public string Username { get; set; }
        public string ID { get; set; }
    }
}