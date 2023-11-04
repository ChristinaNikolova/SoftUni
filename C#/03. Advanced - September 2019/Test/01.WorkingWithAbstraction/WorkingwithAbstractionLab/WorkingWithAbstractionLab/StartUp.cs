using System;
using System.Linq;

namespace WorkingWithAbstractionLab
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double pricePerDay = double.Parse(elements[0]);
            int numberOfDays = int.Parse(elements[1]);
            string season = elements[2];
            string discountType = null;

            if (elements.Length == 4)
            {
                discountType = elements[3];
            }

            double totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, season, discountType);

            Console.WriteLine(totalPrice.ToString("F2"));
        }
    }
}
