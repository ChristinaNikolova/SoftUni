using System;
using System.Linq;

namespace HotelReservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            decimal totalPrice = PriceCalculator.GetTotalPrice(elements);

            Console.WriteLine(totalPrice.ToString("F2"));
        }
    }
}
