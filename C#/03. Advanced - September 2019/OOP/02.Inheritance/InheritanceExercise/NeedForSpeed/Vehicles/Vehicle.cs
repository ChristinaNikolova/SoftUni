using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Vehicles
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        private int horsePower;
        private double fuel;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                this.horsePower = value;
            }
        }

        public double Fuel
        {
            get => this.fuel;
            private set
            {
                this.fuel = value;
            }
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
