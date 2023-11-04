using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products.Foods
{
    public class Food : Product
    {
        private double grams;
        public Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams
        {
            get => this.grams;
            private set
            {
                this.grams = value;
            }
        }
    }
}
