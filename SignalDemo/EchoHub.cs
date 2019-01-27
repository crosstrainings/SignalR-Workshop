using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalDemo.DbModels;
using SignalDemo.Models;
using Microsoft.AspNet.Identity;

namespace SignalDemo
{
    
    [HubName("echo")]
   [Authorize]
    public class EchoHub : Hub
    {
        public void hello(string msg)
        {
            Trace.WriteLine(msg);
        }
        public override Task OnConnected()
        {
            var ConnId = Context.ConnectionId;
            var UserId = Context.User.Identity.GetUserId();
            return Groups.Add(ConnId, UserId);
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        public Task updateMessages(int FriendId)
        {
            var UserId = Context.User.Identity.GetUserId();
            return Clients.Group(FriendId.ToString()).test(Convert.ToInt32(UserId));
        }
    }
}