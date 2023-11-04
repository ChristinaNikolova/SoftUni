using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, 0, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, 0, "n/a")
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

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            private set
            {
                this.engine = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                this.weight = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                this.color = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"{this.Model}:")
                .AppendLine($"{this.Engine}");

            if (this.Weight != 0)
            {
                message.AppendLine($"  Weight: {this.Weight}");
            }
            else
            {
                message.AppendLine($"  Weight: n/a");
            }

            message.Append($"  Color: {this.Color}");


            return message.ToString();
        }
    }
}
