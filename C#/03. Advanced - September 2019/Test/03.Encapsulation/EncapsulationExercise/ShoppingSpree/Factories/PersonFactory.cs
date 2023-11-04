using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Factories
{
    public static class PersonFactory
    {
        public static void Create(string[] elements, List<Person> people)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                string[] currentPersonProps = elements[i]
                    .Split("=")
                    .ToArray();

                string name = currentPersonProps[0];
                double money = double.Parse(currentPersonProps[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
        }
    }
}
