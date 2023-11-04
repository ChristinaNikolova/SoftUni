using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Factories
{
    public static class FoodFactory
    {
        public static IFood Create(string[] elements)
        {
            string typeFood = elements[0];
            int quantity = int.Parse(elements[1]);

            IFood food = null;

            if (typeFood == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (typeFood == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (typeFood == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (typeFood == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
