using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isYoda = false;

            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> toshkoAndSlav = new Queue<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] jedis = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                foreach (string currentJedi in jedis)
                {
                    if (currentJedi[0] == 'm')
                    {
                        masters.Enqueue(currentJedi);
                    }
                    else if (currentJedi[0] == 'k')
                    {
                        knights.Enqueue(currentJedi);
                    }
                    else if (currentJedi[0] == 'p')
                    {
                        padawans.Enqueue(currentJedi);
                    }
                    else if (currentJedi[0] == 't' || currentJedi[0] == 's')
                    {
                        toshkoAndSlav.Enqueue(currentJedi);
                    }
                    else if (currentJedi[0] == 'y')
                    {
                        isYoda = true;
                    }
                }
            }

            StringBuilder finalOutput = new StringBuilder();

            if (isYoda)
            {
                finalOutput.Append(string.Join(" ", masters) + " ")
                    .Append(string.Join(" ", knights) + " ")
                    .Append(string.Join(" ", toshkoAndSlav) + " ")
                    .Append(string.Join(" ", padawans) + " ");
            }
            else
            {
                finalOutput.Append(string.Join(" ", toshkoAndSlav) + " ")
                    .Append(string.Join(" ", masters) + " ")
                    .Append(string.Join(" ", knights) + " ")
                    .Append(string.Join(" ", padawans) + " ");
            }

            Console.WriteLine(finalOutput.ToString().Trim());
        }
    }
}
