using Animals.Animals;
using Animals.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Engine
    {
        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string animalType = input;

                    string[] elements = Console.ReadLine()
                        .Split(" ")
                        .ToArray();

                    Animal animal = AnimalFactory.Create(animalType, elements);

                    Console.WriteLine(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
