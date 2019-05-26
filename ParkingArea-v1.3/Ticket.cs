using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingArea
{
    class Ticket
    {
        public int TicketNumber { get; set; }

        public static int Count = 1;

        public DateTime InTime { get; set; }

        public DateTime ? OutTime { get; set; }
        
        public Ticket()
        {
            this.TicketNumber = Count++ ;
            this.InTime = DateTime.Now;
            this.OutTime = null;
        }

        public DateTime ? SetOutTime()
        {
            this.OutTime = DateTime.Now;
            return OutTime;
        }
    }
}
