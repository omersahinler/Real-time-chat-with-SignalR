using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        readonly ApplicationDbContext _dbContext;
        public ChatHub(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SendMessage(string user, string message)
        {
            Messages messageObject = new Messages()
            {
                Username = user,
                MessageText = message,
                MessageDate = DateTime.Now
            };
            _dbContext.Messages.Add(messageObject);
            await _dbContext.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
