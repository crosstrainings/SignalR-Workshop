using SignalDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalDemo.DbModels
{
    public class Message
    {
        public int Id { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser ToUser { get; set; }
        [ForeignKey("FromUser")]
        public int FromUserId { get; set; }
        [ForeignKey("ToUser")]
        public int ToUserId { get; set; }
        public string Messages { get; set; }
        public DateTime SentDate { get; set; }
    }
}