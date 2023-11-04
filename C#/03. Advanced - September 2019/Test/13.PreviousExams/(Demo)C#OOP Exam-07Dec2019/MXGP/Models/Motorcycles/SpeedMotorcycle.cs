using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MinHorsePowerValue = 50;
        private const int MaxHorsePowerValue = 69;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, 125)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value < MinHorsePowerValue || value > MaxHorsePowerValue)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                base.HorsePower = value;
            }
        }
    }
}
