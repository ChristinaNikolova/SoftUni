using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                List<string> elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = elements[0];
                string criteria = elements[1];
                string parameter = elements[2];

                Func<string, bool> filter = GetTheFilter(criteria, parameter);

                if (command == "Remove")
                {
                    guests.RemoveAll(x => filter(x));
                }
                else if (command == "Double")
                {
                    List<string> guestsToAdd = guests
                        .Where(x => filter(x))
                        .ToList();

                    foreach (string currentGuest in guestsToAdd)
                    {
                        int indexGuest = guests.IndexOf(currentGuest);
                        guests.Insert(indexGuest + 1, currentGuest);
                    }
                }
            }

            bool areAny = guests.Any();
            if (areAny)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Func<string, bool> GetTheFilter(string criteria, string parameter)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(parameter);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(parameter);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(parameter);
            }
            else
            {
                return null;
            }
        }
    }
}
