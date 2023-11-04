using ShoppingSpree.Factories;
using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] peopleInput = Console.ReadLine()
               .Split(";")
               .ToArray();

                List<Person> people = new List<Person>();

                PersonFactory.Create(peopleInput, people);

                string[] productsInput = Console.ReadLine()
                  .Split(";", StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

                List<Product> products = new List<Product>();

                ProductFactory.Create(productsInput, products);

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] elements = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string personName = elements[0];
                    string productName = elements[1];

                    int indexPerson = people.FindIndex(x => x.Name == personName);
                    int indexProduct = products.FindIndex(x => x.Name == productName);

                    if (indexPerson == -1 || indexProduct == -1)
                    {
                        continue;
                    }

                    string result = people[indexPerson].BuyProduct(products[indexProduct]);

                    Console.WriteLine(result);
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
