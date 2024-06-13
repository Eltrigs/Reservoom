using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get;}
        public string username { get;}
        public DateTime startTime { get;}
        public DateTime endTime { get;}
        public TimeSpan length => endTime - startTime;

        public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
        {
            this.RoomID = roomID;
            this.startTime = startTime;
            this.endTime = endTime;
            this.username = username;
        }
    }
}
