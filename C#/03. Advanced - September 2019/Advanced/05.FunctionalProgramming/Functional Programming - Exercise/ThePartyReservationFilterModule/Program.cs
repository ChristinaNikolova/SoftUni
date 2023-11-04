using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> originals = new List<string>();
            originals.AddRange(guests);

            List<string> allRemovedGuests = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] elements = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = elements[0];
                string criteria = elements[1];
                string parameter = elements[2];

                Func<string, bool> filter = GetTheFilter(criteria, parameter);

                if (command == "Add filter")
                {
                    List<string> currentRemovedGuests = guests
                        .Where(x => filter(x))
                        .ToList();

                    allRemovedGuests.AddRange(currentRemovedGuests);
                    guests.RemoveAll(x => filter(x));
                }
                else if (command == "Remove filter")
                {
                    List<string> guestsToAdd = allRemovedGuests
                        .Where(x => filter(x))
                        .ToList();

                    allRemovedGuests.RemoveAll(x => filter(x));
                    guests.AddRange(guestsToAdd);

                    List<string> temp = new List<string>();

                    foreach (string original in originals)
                    {
                        foreach (string currentGuest in guests)
                        {
                            if (original == currentGuest)
                            {
                                temp.Add(original);
                            }
                        }
                    }

                    guests = temp;
                }
            }

            bool areAny = guests.Any();
            if (areAny)
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }

        private static Func<string, bool> GetTheFilter(string criteria, string parameter)
        {
            if (criteria == "Starts with")
            {
                return x => x.StartsWith(parameter);
            }
            else if (criteria == "Ends with")
            {
                return x => x.EndsWith(parameter);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(parameter);
            }
            else if (criteria == "Contains")
            {
                return x => x.Contains(parameter);
            }
            else
            {
                return null;
            }
        }
    }
}
