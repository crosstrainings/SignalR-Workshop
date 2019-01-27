using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SignalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalDemo.DbModels
{
    public class UserConnection
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int UserId { get; set; }
    }
}