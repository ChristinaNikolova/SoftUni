using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Factories
{
    public static class PizzaFactory
    {
        public static Pizza Create(string[] elements, Dough dough)
        {
            string name = elements[1];

            Pizza pizza = new Pizza(name, dough);

            return pizza;
        }
    }
}
