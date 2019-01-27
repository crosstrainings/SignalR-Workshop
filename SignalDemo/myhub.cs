using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalDemo
{
    [HubName("myhubs")]
    public class myhub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();//Some Comment HERE
        }

        public override Task OnConnected()
        {
            var UserId= Context.User.Identity.GetUserId();
            string ConnId = Context.ConnectionId;
            return Groups.Add(ConnId, UserId);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public Task updateMessages(int FriendId)
        {
           var UserId= Context.User.Identity.GetUserId();
           return Clients.Group(FriendId.ToString()).test(Convert.ToInt32(UserId));
        }


    }
}