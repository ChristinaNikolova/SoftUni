using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Factories;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IAnimal> animals = new List<IAnimal>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalElements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IAnimal animal = AnimalFactory.Create(animalElements);
                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                string[] foodElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IFood food = FoodFactory.Create(foodElements);

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
