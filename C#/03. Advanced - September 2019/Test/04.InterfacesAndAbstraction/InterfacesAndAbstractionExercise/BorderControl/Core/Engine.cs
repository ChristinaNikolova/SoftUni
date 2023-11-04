using BorderControl.Contracts;
using BorderControl.Factories;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            //List<IIdentifiable> identifiables = new List<IIdentifiable>();

            //string input = string.Empty;

            //while ((input = Console.ReadLine()) != "End")
            //{
            //    string[] elements = input
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //        .ToArray();

            //    IIdentifiable identifiable = IdentifiableFactory.Create(elements);
            //    identifiables.Add(identifiable);
            //}

            //string targetId = Console.ReadLine();

            //identifiables = identifiables
            //    .Where(x => x.Id.EndsWith(targetId))
            //    .ToList();

            //foreach (IIdentifiable identifiable in identifiables)
            //{
            //    Console.WriteLine(identifiable.Id);
            //}

            //List<IBirthable> birthables = new List<IBirthable>();

            //string input = string.Empty;

            //while ((input = Console.ReadLine()) != "End")
            //{
            //    string[] elements = input
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //        .ToArray();

            //    try
            //    {
            //        IBirthable birthable = BirthtableFactory.Create(elements);
            //        birthables.Add(birthable);
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}

            //string targetBirthdate = Console.ReadLine();

            //birthables = birthables
            //    .Where(x => x.Birthdate.EndsWith(targetBirthdate))
            //    .ToList();

            //foreach (IBirthable birthable in birthables)
            //{
            //    Console.WriteLine(birthable.Birthdate);
            //}

            List<Person> people = new List<Person>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person person = PersonFactory.Create(elements);
                people.Add(person);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine())!= "End")
            {
                string targetName = input;

                Person targetPerson = people
                    .FirstOrDefault(x => x.Name == targetName);

                bool isValid = targetPerson != null;
                if (!isValid)
                {
                    continue;
                }

                targetPerson.BuyFood();
            }

            int totalFood = people
                .Select(x => x.Food)
                .Sum();

            Console.WriteLine(totalFood);
        }
    }
}
