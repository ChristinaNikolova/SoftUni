using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MinHorsePower = 50;
        private const int MaxHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, 125)
        {
        }

        //public int HorsePower
        //{
        //    get => this.HorsePower;
        //    set
        //    {
        //        if (value < MinHorsePower || value > MaxHorsePower)
        //        {
        //            throw new ArgumentException($"Invalid horse power: {value}.");
        //        }

        //        this.HorsePower = value;
        //    }
        //}

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                base.HorsePower = value;
            }
        }
    }
}
