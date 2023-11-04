using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private const string DefaultColor = "n/a";
        private const int DefaultWeight = -1;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine, weight, DefaultColor)
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, DefaultWeight, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, DefaultWeight, DefaultColor)
        {
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public int Weight { get; private set; }

        public string Color { get; private set; }


        public override string ToString()
        {
            StringBuilder carOutput = new StringBuilder();

            carOutput.AppendLine($"{this.Model}:");
            carOutput.AppendLine($"{this.Engine}");

            if (this.Weight == DefaultWeight)
            {
                carOutput.AppendLine($"  Weight: {DefaultColor}");
            }
            else
            {
                carOutput.AppendLine($"  Weight: {this.Weight}");
            }

            carOutput.Append($"  Color: {this.Color}");

            return carOutput.ToString();
        }
    }
}
