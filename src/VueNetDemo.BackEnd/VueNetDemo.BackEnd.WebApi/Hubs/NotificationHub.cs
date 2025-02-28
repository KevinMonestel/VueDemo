﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueNetDemo.BackEnd.WebApi.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("Receive", message);
        }
    }
}
