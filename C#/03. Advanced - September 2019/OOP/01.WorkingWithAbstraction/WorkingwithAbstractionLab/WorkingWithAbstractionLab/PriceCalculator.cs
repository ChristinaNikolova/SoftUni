using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithAbstractionLab
{
    public static class PriceCalculator
    {
        public static double GetTotalPrice(double pricePerDay, int numberOfDays, string season, string discountType)
        {
            
            int multiplayer = (int)Enum.Parse<Season>(season);


            double totalPrice = pricePerDay *
                numberOfDays *
                multiplayer;

            if (discountType != null)
            {
                int multiPlayerDiscount = (int)Enum.Parse<DiscountType>(discountType);

                totalPrice -= totalPrice * multiPlayerDiscount / 100;
            }

            return totalPrice;

        }
    }
}
