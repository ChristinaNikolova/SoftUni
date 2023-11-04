using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(string[] elements)
        {
            decimal pricePerDay = decimal.Parse(elements[0]);
            int numberOfDays = int.Parse(elements[1]);
            string season = elements[2];

            int seasonMultiplier = (int)Enum.Parse<Season>(season);

            decimal totalPrice = pricePerDay * numberOfDays * seasonMultiplier;

            if (elements.Length == 4)
            {
                string discountType = elements[3];

                int distcountMultiplier = (int)Enum.Parse<DiscountType>(discountType);

                totalPrice -= totalPrice * distcountMultiplier / 100;
            }

            return totalPrice;
        }
    }
}
