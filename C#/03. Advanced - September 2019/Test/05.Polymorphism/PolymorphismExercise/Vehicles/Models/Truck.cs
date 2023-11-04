using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double DefaultIncreaseFuelConsumptionSummer = 1.6;

        public Truck(double fuelQuantity, double fuelCnsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelCnsumptionPerKm + DefaultIncreaseFuelConsumptionSummer, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= 0.05 * liters;
        }
    }
}
