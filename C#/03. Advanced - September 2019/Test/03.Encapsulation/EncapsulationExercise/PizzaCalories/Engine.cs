using PizzaCalories.Factories;
using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaElements = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string[] doughElements = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                Dough dough = DoughFactory.Create(doughElements);

                Pizza pizza = PizzaFactory.Create(pizzaElements, dough);

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingElements = input
                        .Split(" ")
                        .ToArray();

                    Topping topping = ToppingFactory.Create(toppingElements);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
