using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalDemo
{
    public class testing : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}