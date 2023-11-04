using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const int MinLenghtName = 1;
        private const int MaxLenghtName = 15;
        private const int MaxToppingsCount = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinLenghtName || value.Length > MaxLenghtName)
                {
                    throw new ArgumentException($"Pizza name should be between {MinLenghtName} and {MaxLenghtName} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            private set
            {
                this.dough = value;
            }
        }

        public int ToppingsCount => this.toppings.Count;

        public double Calories => this.GetTheCalories();

        public void AddTopping(Topping topping)
        {
            bool isFreeSpace = this.ToppingsCount + 1 <= MaxToppingsCount;
            if (!isFreeSpace)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }

            this.toppings.Add(topping);
        }

        private double GetTheCalories()
        {
            double totalCalories = this.Dough.Calories +
                this.toppings.Select(x => x.Calories)
                .Sum();

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}
