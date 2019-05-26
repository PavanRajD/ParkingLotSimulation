using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingArea
{
    class ParkingLot
    {
        List<Parkslot> parkingLot;
     
        public ParkingLot()
        {
            parkingLot = new List<Parkslot>();
        }

        public void AddVehicleSpace(VehicleType type,int count)
        {
            for(int slot = 1; slot <= count; slot++)
            {
                parkingLot.Add(new Parkslot(type,slot));
            }
        }


        public Ticket ParkVehicle(VehicleType type,string id)
        {
            var EmptyArea = parkingLot.FirstOrDefault(c => c.TypeOfVehicle == type && c.Status == SlotStatus.Free);

            if (EmptyArea == null)
            {
                throw new Exception("SpaceNotFound");
            }
            else
            {
                EmptyArea.Status = SlotStatus.Occupied;
                return EmptyArea.SetVehicle(type,id);
            }
        }


        public Parkslot RemoveVehicle(VehicleType type, int ticket)
        {
            var vehicle = parkingLot.FirstOrDefault(c => c.TypeOfVehicle == type && c.GetTicket() == ticket && c.Status == SlotStatus.Occupied);
            if (vehicle == null)
            {
                throw new Exception("Ticket not found");
            }
            else
            {
                vehicle.Status = SlotStatus.Free;
                vehicle.NewTicket.SetOutTime();
                return vehicle;
            }
        }


        public int FreeVehicleSpace(VehicleType type)
        {
            return parkingLot.Count(c => c.TypeOfVehicle == type && c.Status == SlotStatus.Free);
        }

        public int OccupiedVehicleSpace(VehicleType type)
        {
            return parkingLot.Count(c => c.TypeOfVehicle == type && c.Status == SlotStatus.Occupied);
        }

        public List<Parkslot> GetAllvehicles()
        {
            return parkingLot;
        }
        
    }
}