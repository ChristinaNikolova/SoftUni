using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

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
            }

            people = people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            bool areAny = people.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Select(x => $"{x.Name} - {x.Age}")));
            }

            //Family family = new Family();

            //int numberOfLines = int.Parse(Console.ReadLine());

            //for (int i = 0; i < numberOfLines; i++)
            //{
            //    string[] elements = Console.ReadLine()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //        .ToArray();

            //    string name = elements[0];
            //    int age = int.Parse(elements[1]);

            //    Person person = new Person(name, age);
            //    family.AddMember(person);
            //}

            //Person oldestPerson = family.GetOldestMember();

            //Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
