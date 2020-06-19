using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;
using TicketOnLine_webSite.Services;

namespace TicketOnLine_webSite.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public static async  void SaveDb(string Message)
        {
            CommentaireWeb web = new CommentaireWeb
            {
                Commentaires = Message,
                IdClient = 0,
                IdEvent = 0
            };
            ServicesCommentaire.Post(web);
        }
    }
}
