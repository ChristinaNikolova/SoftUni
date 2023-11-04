using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();
            SortedSet<Person> sortedPeope = new SortedSet<Person>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = elements[0];
                int age = int.Parse(elements[1]);

                Person person = new Person(name, age);

                people.Add(person);
                sortedPeope.Add(person);
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeope.Count);
        }
    }
}
