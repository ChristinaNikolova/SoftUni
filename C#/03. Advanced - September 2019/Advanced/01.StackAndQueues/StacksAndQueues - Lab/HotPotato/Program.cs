using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            int numberToRemove = int.Parse(Console.ReadLine());

            int counterKids = 0;

            while (kids.Count > 1)
            {
                counterKids++;
                string currentKid = kids.Dequeue();

                bool hasToRemove = counterKids % numberToRemove == 0;
                if (hasToRemove)
                {
                    Console.WriteLine($"Removed {currentKid}");
                }
                else
                {
                    kids.Enqueue(currentKid);
                }
            }

            string winner = kids.Dequeue();

            Console.WriteLine($"Last is {winner}");
        }
    }
}
