using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products.Foods.Desserts
{
    public class Dessert : Food
    {
        private double calories;
        public Dessert(string name, decimal price, double grams, double calories)
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public double Calories
        {
            get => this.calories;
            private set
            {
                this.calories = value;
            }
        }
    }
}
