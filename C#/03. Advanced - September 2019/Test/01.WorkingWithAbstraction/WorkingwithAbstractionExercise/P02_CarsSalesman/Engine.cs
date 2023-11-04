using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private const string DefaultEfficiency = "n/a";
        private const int DefaultDisplacement = -1;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, DefaultEfficiency)
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, DefaultDisplacement, efficiency)
        {
        }

        public Engine(string model, int power)
             : this(model, power, DefaultDisplacement, DefaultEfficiency)
        {
        }

        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displacement { get; private set; }

        public string Efficiency { get; private set; }

        public override string ToString()
        {
            StringBuilder engineOutput = new StringBuilder();

            engineOutput.AppendLine($"  {this.Model}:");
            engineOutput.AppendLine($"    Power: {this.Power}");

            if (this.Displacement == DefaultDisplacement)
            {
                engineOutput.AppendLine($"    Displacement: {DefaultEfficiency}");
            }
            else
            {
                engineOutput.AppendLine($"    Displacement: {this.Displacement}");
            }

            engineOutput.Append($"    Efficiency: {this.Efficiency}");

            return engineOutput.ToString();
        }
    }
}
