using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                string currentInvitation = input;

                bool isLenghtValid = currentInvitation.Length == 8;
                if (!isLenghtValid)
                {
                    continue;
                }

                bool isVip = char.IsDigit(currentInvitation[0]);
                if (isVip)
                {
                    vips.Add(currentInvitation);
                }
                else
                {
                    regulars.Add(currentInvitation);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                string currentGuest = input;

                vips.Remove(currentGuest);
                regulars.Remove(currentGuest);
            }

            int guests = vips.Count + regulars.Count;

            Console.WriteLine(guests);

            bool areVips = vips.Any();
            if (areVips)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vips));
            }

            bool areRegulars = regulars.Any();
            if (areRegulars)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regulars));
            }
        }
    }
}
