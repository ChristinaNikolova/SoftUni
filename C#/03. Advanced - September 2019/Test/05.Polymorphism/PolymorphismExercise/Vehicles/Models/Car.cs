using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double DefaultIncreaseFuelConsumptionSummer = 0.9;

        public Car(double fuelQuantity, double fuelCnsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelCnsumptionPerKm + DefaultIncreaseFuelConsumptionSummer, tankCapacity)
        {
        }
    }
}
