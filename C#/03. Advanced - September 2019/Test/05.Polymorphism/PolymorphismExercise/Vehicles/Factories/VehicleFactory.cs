using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Contracts;

namespace Vehicles.Factories
{
    public static class VehicleFactory
    {
        public static IVehicle Create(string[] elements)
        {
            string vehicleType = elements[0];
            double fuelQuantity = double.Parse(elements[1]);
            double fuelConsumption = double.Parse(elements[2]);
            double tankCapacity = double.Parse(elements[3]);

            IVehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
