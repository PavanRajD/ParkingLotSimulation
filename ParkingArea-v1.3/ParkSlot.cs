using System;
using System.Collections.Generic;
using System.Linq;
namespace ParkingArea
{
    class Parkslot
    {
        public SlotStatus Status { get; set; }

        public int SlotNumber { get; set; }
        
        public VehicleType TypeOfVehicle { get; set; }

        public Ticket NewTicket;

        public Vehicle NewVehicle;

        public Parkslot(VehicleType type,int id)
        {
            Status = SlotStatus.Free;
            TypeOfVehicle = type;
            SlotNumber = id;
        }

        public Ticket SetVehicle(VehicleType type,string id)
        {
            NewVehicle = new Vehicle(type, id);
            NewTicket = new Ticket();
            return NewTicket;
        }

        public int GetTicket()
        {
            return NewTicket.TicketNumber;
        }
        public string GetVehicleNumber()
        {
            return NewVehicle.VehicleNumber;
        }
    }
}
