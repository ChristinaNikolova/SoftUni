using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int maxOrder = orders.Max();

            Console.WriteLine(maxOrder);

            bool isSuccess = true;

            while(orders.Any())
            {
                int currentOrder = orders.Peek();

                bool isFoodEnough = currentOrder <= totalFood;
                if (!isFoodEnough)
                {
                    isSuccess = false;
                    break;
                }

                totalFood -= currentOrder;
                orders.Dequeue();
            }

            if (isSuccess)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
