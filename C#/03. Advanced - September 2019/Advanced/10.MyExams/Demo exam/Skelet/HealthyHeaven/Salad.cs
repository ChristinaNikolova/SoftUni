using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;
        private string name;

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int GetTotalCalories()
        {
            int totalCalories = 0;

            foreach (Vegetable vegetable in this.products)
            {
                totalCalories += vegetable.Calories;
            }

            return totalCalories;
        }

        public int GetProductCount()
        {
            return this.products.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (Vegetable vegetable in this.products)
            {
                message.AppendLine(vegetable.ToString());
            }


            return message.ToString().TrimEnd();
        }
    }
}
