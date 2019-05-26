using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingArea
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parking = new ParkingLot();
            Console.WriteLine("*********     ParkingArea    ***********");

            foreach(int vehicletype in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine("Enter No.of Slots For{0}",(VehicleType)vehicletype);
                int count = ReadInput();
                parking.AddVehicleSpace((VehicleType)vehicletype,count);
            }
            
            bool Option = true;

            while (Option)
            {
                Console.WriteLine(".........MENU..........");
                Console.WriteLine("1.Park vehicle\n2.Unpark Vehicle\n3.Display Occupied Vehicle Slots\n4.Display Remaining Slot Count\n5.exit\n");

                int value = ReadInput();

                if (value == 5)
                {
                    Environment.Exit(1);
                }
                else
                {
                    switch (value)
                    {
                        case 1:
                            
                            Console.WriteLine("Select vehicle to Park\n1.TwoWheeler\n2.FourWheeler\n3.Other\n");
                            int choice = ReadInput();

                            VehicleType type;
                            if (choice == 1)
                                type = VehicleType.TwoWheeler;
                            else if (choice == 2)
                                type = VehicleType.FourWheeler;
                            else 
                                type = VehicleType.HeavyWheeler;

                            Console.WriteLine("Enter vehicle Id");
                            string id = Console.ReadLine();

                            Ticket ticket = parking.ParkVehicle(type, id);
                            
                            Console.WriteLine("Vehicle Sucessfully Parked........At time ..{1}\nYour Ticket is :PrkId{0}\n\n",ticket.TicketNumber,ticket.InTime);
                            break;

                        case 2:
                            Console.Clear();

                            Console.WriteLine("Select vehicle to UnPark\n1.TwoWheeler\n2.FourWheeler\n3.Other\n");
                            int unparkChoice = ReadInput();

                            VehicleType Unparktype;
                            if (unparkChoice == 1)
                                Unparktype = VehicleType.TwoWheeler;
                            else if (unparkChoice == 2)
                                Unparktype = VehicleType.FourWheeler;
                            else
                                Unparktype = VehicleType.HeavyWheeler;
                           
                            Console.WriteLine("Enter Ticket Number:");
                            int vehicleticket = ReadInput();

                            Parkslot removedvehicle = parking.RemoveVehicle(Unparktype,vehicleticket);
                            Console.WriteLine("Vehicle Unparked Sucessfully...\nVehicleType {0}\tVehicle no. {1}\tIn time :{2} OutTime :{3}", removedvehicle.TypeOfVehicle, removedvehicle.GetVehicleNumber(), removedvehicle.NewTicket.InTime, removedvehicle.NewTicket.OutTime);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("All Occupied Slots::");
                            Console.WriteLine("Two Wheeler Occupied Slots   = " + (parking.OccupiedVehicleSpace(VehicleType.TwoWheeler)));
                            Console.WriteLine("Four Wheeler Occupied Slots  = " + (parking.OccupiedVehicleSpace(VehicleType.FourWheeler)));
                            Console.WriteLine("Other Vehicle Occupied Slots = " + (parking.OccupiedVehicleSpace(VehicleType.HeavyWheeler)));

                            List<Parkslot> vehicleList = parking.GetAllvehicles();

                            foreach (Parkslot vehicle in vehicleList)
                            {
                                if(vehicle.Status != SlotStatus.Free)
                                     Console.WriteLine("\n{5} slot {0} \nVehicleType {1}\tVehicle no. {2}\tIn time :{3} OutTime :{4}", vehicle.SlotNumber , vehicle.TypeOfVehicle ,vehicle.GetVehicleNumber(),vehicle.NewTicket.InTime,vehicle.NewTicket.OutTime,vehicle.TypeOfVehicle);
                            }

                            Console.WriteLine("\n\n");
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("All Free Slots::");
                            Console.WriteLine("Two Wheeler Free Slots   = " + parking.FreeVehicleSpace(VehicleType.TwoWheeler));
                            Console.WriteLine("Four Wheeler Free Slots  = " + parking.FreeVehicleSpace(VehicleType.FourWheeler));
                            Console.WriteLine("Other Vehicle Free Slots = " + parking.FreeVehicleSpace(VehicleType.HeavyWheeler));
                            break;
                        
                    }
                }
            }
            int ReadInput()
            {
                while (true)
                {
                    try
                    {
                        return int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("please enter integer value only..");
                    }
                }
            }
        }
    }
}
