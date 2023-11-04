using System;
using System.Globalization;

namespace DateModifier
{
    public class DateModifier
    {
        public static double GetTheDiffrenceInDaysBetweenTwoDays(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.ParseExact(firstDate, "yyyy M d", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondDate, "yyyy M d", CultureInfo.InvariantCulture);

            double days = Math.Abs(startDate.Subtract(endDate).TotalDays);

            return days;
        }
    }
}
