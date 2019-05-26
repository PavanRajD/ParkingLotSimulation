using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingArea
{
    class Vehicle
    {
        public VehicleType VehicleType { get; set; }

        public string VehicleNumber { get; set; }

        public Vehicle(VehicleType type,string vehicleId)
        {
            this.VehicleType = type;
            this.VehicleNumber = vehicleId;
        }
    }
}
