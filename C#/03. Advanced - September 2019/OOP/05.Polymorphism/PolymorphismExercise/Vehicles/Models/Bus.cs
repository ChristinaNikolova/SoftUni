using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double DefaultIncreaseFuelConsumptionSummer = 1.4;

        public Bus(double fuelQuantity, double fuelCnsumptionPerKm, double tankCapacity)
                    : base(fuelQuantity, fuelCnsumptionPerKm + DefaultIncreaseFuelConsumptionSummer, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelCnsumptionPerKm -= DefaultIncreaseFuelConsumptionSummer;
            string result  = base.Drive(distance);

            this.FuelCnsumptionPerKm += DefaultIncreaseFuelConsumptionSummer;

            return result;
        }
    }
}
