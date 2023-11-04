using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
            :this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency)
           : this(model, power, 0, efficiency)
        {
        }

        public Engine(string model, int power)
           : this(model, power, 0, "n/a")
        {
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                this.power = value;
            }
        }

        public int Displacement
        {
            get
            {
                return this.displacement;
            }
            private set
            {
                this.displacement = value;
            }
        }

        public string Efficiency
        {
            get
            {
                return this.efficiency;
            }
            private set
            {
                this.efficiency = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"  {this.Model}:")
                .AppendLine($"    Power: {this.Power}");

            if (this.Displacement != 0)
            {
                message.AppendLine($"    Displacement: {this.Displacement}");
            }
            else
            {
                message.AppendLine($"    Displacement: n/a");
            }

            message.Append($"    Efficiency: {this.Efficiency}");

            return message.ToString().TrimEnd();
        }
    }
}
