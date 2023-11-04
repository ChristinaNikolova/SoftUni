using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = elements[0];
                int age = int.Parse(elements[1]);
                string town = elements[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int numberTargetPerson = int.Parse(Console.ReadLine());

            Person targetPerson = people[numberTargetPerson - 1];

            int counterEqualPeople = 0;
            int counterNotEqualPeople = 0;

            foreach (Person person in people)
            {
                bool areEqual = person.CompareTo(targetPerson) == 0;
                if (areEqual)
                {
                    counterEqualPeople++;
                }
                else
                {
                    counterNotEqualPeople++;
                }
            }

            bool areFound = counterEqualPeople > 1;
            if (areFound)
            {
                Console.WriteLine($"{counterEqualPeople} {counterNotEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
