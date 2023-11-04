using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int BaseCaloriesPerGram = 2;
        private const int MinValueWeight = 1;
        private const int MaxValueWeight = 50;

        private string type;
        private double weight;
        private Dictionary<string, double> typesAndModifiers;

        public Topping(string type, double weight)
        {
            this.typesAndModifiers = new Dictionary<string, double>();
            this.GetTheTypesAndModifiers();

            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!this.typesAndModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinValueWeight || value > MaxValueWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinValueWeight}..{MaxValueWeight}].");
                }

                this.weight = value;
            }
        }

        public double Calories => this.GetTheCalories();

        private double GetTheCalories()
        {
            double calories = BaseCaloriesPerGram *
                this.Weight *
                this.typesAndModifiers[this.Type.ToLower()];

            return calories;
        }

        private void GetTheTypesAndModifiers()
        {
            typesAndModifiers.Add("meat", 1.2);
            typesAndModifiers.Add("veggies", 0.8);
            typesAndModifiers.Add("cheese", 1.1);
            typesAndModifiers.Add("sauce", 0.9);
        }
    }
}
