using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int MinHorsePowerValue = 70;
        private const int MaxHorsePowerValue = 100;
        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, 450)
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
