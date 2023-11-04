using System;

namespace DateModifier
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            double days = DateModifier.GetTheDiffrenceInDaysBetweenTwoDays(firstDate, secondDate);

            Console.WriteLine(days);
        }
    }
}
