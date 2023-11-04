using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (customers.Any())
                    {
                        string currentCustomer = customers.Dequeue();

                        Console.WriteLine(currentCustomer);
                    }

                    continue;
                }

                string currentName = input;
                customers.Enqueue(currentName);
            }

            int countRemainingCustomers = customers.Count;

            Console.WriteLine($"{countRemainingCustomers} people remaining.");
        }
    }
}
