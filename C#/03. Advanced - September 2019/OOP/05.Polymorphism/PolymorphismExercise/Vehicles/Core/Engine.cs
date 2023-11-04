using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Factories;
using Vehicles.Models;
using Vehicles.Models.Contracts;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            int numberOfVehicles = 3;

            for (int i = 0; i < numberOfVehicles; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IVehicle vehicle = VehicleFactory.Create(elements);
                vehicles.Add(vehicle);
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IVehicle vehicle = GetTheVehicle(vehicles, elements);

                bool isFound = vehicle != null;
                if (!isFound)
                {
                    continue;
                }

                string command = elements[0];
                double value = double.Parse(elements[2]);

                if (command == "Drive")
                {
                    DriveCommand(vehicle, value);
                }
                else if (command == "Refuel")
                {
                    RefuelCommand(vehicle, value);
                }
                else if (command == "DriveEmpty")
                {
                    DriveEmptyCommand(vehicle, value);
                }
            }

            PrintResult(vehicles);
        }

        private static void DriveEmptyCommand(IVehicle vehicle, double value)
        {
            Bus bus = vehicle as Bus;
            string result = bus.DriveEmpty(value);

            Console.WriteLine(result);
        }

        private static void PrintResult(List<IVehicle> vehicles)
        {
            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private static void RefuelCommand(IVehicle vehicle, double value)
        {
            try
            {
                vehicle.Refuel(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DriveCommand(IVehicle vehicle, double value)
        {
            string result = vehicle.Drive(value);

            Console.WriteLine(result);
        }

        private static IVehicle GetTheVehicle(List<IVehicle> vehicles, string[] elements)
        {
            string vehicleType = elements[1];

            IVehicle vehicle = vehicles
                .FirstOrDefault(x => x.GetType().Name == vehicleType);

            return vehicle;
        }
    }
}
