using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace webApi
{
    public class ReturnoHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public string Activate()
        {
            return "Monitor Activated";
        }

        public void sendMessage(string mensagem)
        {
            Clients.All.sendMessage(mensagem);
        }

        public static void SendMessage(string message)
        {

            GlobalHost.ConnectionManager.GetHubContext<ReturnoHub>().Clients.All.sendMessage(message);
        }
    }
}