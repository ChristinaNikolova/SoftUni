using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Factories
{
    public static class DoughFactory
    {
        public static Dough Create(string[] elements)
        {
            string flourType = elements[1];
            string bakingTechnique = elements[2];
            double weight = double.Parse(elements[3]);

            Dough dough = new Dough(flourType, bakingTechnique, weight);

            return dough;
        }
    }
}
