using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelCnsumptionPerKm;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelCnsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelCnsumptionPerKm = fuelCnsumptionPerKm;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelCnsumptionPerKm
        {
            get => this.fuelCnsumptionPerKm;
            protected set
            {
                this.fuelCnsumptionPerKm = value;
            }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                this.tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            bool isFuelEnough = this.FuelQuantity >= this.FuelCnsumptionPerKm * distance;
            if (!isFuelEnough)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= this.FuelCnsumptionPerKm * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            bool isCapacityEnough = this.FuelQuantity + liters <= this.tankCapacity;
            if (!isCapacityEnough)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            bool isPositiveValue = liters > 0;
            if (!isPositiveValue)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
