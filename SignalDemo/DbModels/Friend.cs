using SignalDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalDemo.DbModels
{
    public class Friend
    {
        public int Id { get; set; }
        public virtual ApplicationUser User1 { get; set; }
        public virtual ApplicationUser User2 { get; set; }
        [ForeignKey("User1")]
        public int UserId1 { get; set; }
        [ForeignKey("User2")]
        public int UserId2 { get; set; }
    }
}