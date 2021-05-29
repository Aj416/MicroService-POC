using System;
using System.Collections.Generic;
using System.Text;

namespace CoreService.Events
{
    public abstract class Event : Message
    {
        public DateTime TimeStamp { get; protected set; }
        public Event()
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}
