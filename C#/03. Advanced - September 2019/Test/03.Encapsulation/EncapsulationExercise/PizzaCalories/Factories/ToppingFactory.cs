using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Factories
{
    public static class ToppingFactory
    {
        public static Topping Create(string[] elements)
        {
            string type = elements[1];
            double weight = double.Parse(elements[2]);

            Topping topping = new Topping(type, weight);

            return topping;
        }
    }
}
