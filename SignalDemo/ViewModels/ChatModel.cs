using SignalDemo.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalDemo.ViewModels
{
    public class ChatModel
    {
        public ChatModel()
        {
            Messages = new List<Message>();
        }
        public List<Friend> Friends { get; set; }
        public List<Message> Messages { get; set; }
    }
}